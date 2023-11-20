using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions
{
    public class MajorCoursesActions : IMajorCoursesDAL
    {
        readonly SeminarWebsiteContext _DB;
        readonly IMajorDAL _majorDAL;
        readonly ICoursesDAL _coursesDAL;

        #region C-tor
        public MajorCoursesActions(SeminarWebsiteContext DB, IMajorDAL majorDAL, ICoursesDAL coursesDAL)
        {
            _DB = DB;
            _majorDAL = majorDAL;
            _coursesDAL = coursesDAL;
        }
        #endregion

        //Get
        #region GetAllMajorCourses
        public List<MajorCoursesTbl> GetAllMajorCourses()
        {
            return _DB.MajorCoursesTbls.ToList();
        }
        #endregion

        #region GetMajorAndCourseBySeminarCodeAndMajorCode
        public List<MajorCoursesTbl> GetMajorAndCourseBySeminarCodeAndMajorCode(short seminarCode, short majorCode)
        {
            List<MajorTbl> majorTbls = _majorDAL.GetMajorBySeminarCode(seminarCode);
            List<MajorCoursesTbl> majorCoursesTbls = new List<MajorCoursesTbl>();

            foreach (MajorTbl item in majorTbls)
            {
                List<MajorCoursesTbl> m = GetMajorCoursesByMajorCode(item.MajorCode);
                if (m != null)
                    foreach (MajorCoursesTbl item1 in m)
                        majorCoursesTbls.Add(item1);
            }
            return majorCoursesTbls;
        }
        #endregion

        #region GetMajorCoursesByMajorCodeAndCourseCode
        public MajorCoursesTbl GetMajorCoursesByMajorCodeAndCourseCode(short majorCode, short courseCode)
        {
            return GetMajorCoursesByMajorCode(majorCode).FirstOrDefault(x => x.CourseCode.Equals(courseCode));
        }
        #endregion

        #region GetMajorAndCourseBySeminarCodeAndStaffCode
        public List<MajorCoursesTbl> GetMajorAndCourseBySeminarCodeAndStaffCode(short seminarCode, short staffCode)
        {
            List<short> majorCodesInSeminar = new List<short>();
            List<MajorCoursesTbl> majors = new List<MajorCoursesTbl>();

            _majorDAL.GetMajorBySeminarCode(seminarCode).ForEach(x =>
                majorCodesInSeminar.Add(x.MajorCode)
            );

            GetMajorCoursesTblByCourseTeacherCode(staffCode).ForEach(x =>
            {
                if (majorCodesInSeminar.IndexOf(x.MajorCode) != -1)
                    majors.Add(x);
            });

            return majors;
        }
        #endregion

        #region GetMajorCourseByMajorCode
        public MajorCoursesTbl GetMajorCourseByMajorCode(short majorCode)
        {
            return _DB.MajorCoursesTbls.FirstOrDefault(x => x.MajorCode.Equals(majorCode));
        }
        #endregion

        #region GetMajorCourseByCourseCodeForTheMajor
        public MajorCoursesTbl GetMajorCourseByCourseCodeForTheMajor(short courseCodeForTheMajor)
        {
            return _DB.MajorCoursesTbls.FirstOrDefault(x => x.CourseCodeForTheMajor.Equals(courseCodeForTheMajor));
        }
        #endregion

        #region GetMajorCoursesByMajorCode
        public List<MajorCoursesTbl> GetMajorCoursesByMajorCode(short majorCode)
        {
            return _DB.MajorCoursesTbls.Where(x => x.MajorCode.Equals(majorCode)).ToList();
        }
        #endregion

        #region GetMajorCoursesByMajorCodeAndByCourseGrade
        public List<MajorCoursesTbl> GetMajorCoursesByMajorCodeAndByCourseGrade(short majorCode, string courseGrade)
        {
            var minDate = DateTime.Now.Month < 9 ? DateTime.Now.Year - 1 : DateTime.Now.Year;
            return _DB.MajorCoursesTbls.Where(x => x.MajorCode.Equals(majorCode) && x.CourseGrade.Equals(courseGrade) && x.CourseStartYear >= new DateTime(minDate, 09, 01)).ToList();
        }
        #endregion

        #region GetMajorCoursesTblByCourseTeacherCode
        public List<MajorCoursesTbl> GetMajorCoursesTblByCourseTeacherCode(short courseTeacherCode)
        {
            List<MajorCoursesTbl> majorCoursesTbls = GetAllMajorCourses().Where(x => x.CourseTeacherCode.Equals(courseTeacherCode)).ToList();
            return majorCoursesTbls;
        }
        #endregion

        //Post
        #region AddAMajorCoursesByMajorCodeAndCourseGradeAndCourseNameAndCourseTeacherCode
        public MajorCoursesTbl AddAMajorCoursesByMajorCodeAndCourseGradeAndCourseNameAndCourseTeacherCode(short majorCode, string courseGrade, string courseName, short courseTeacherCode)
        {
            MajorTbl majorTbl = _majorDAL.GetMajorByMajorCode(majorCode);
            CoursesTbl coursesTbl = _coursesDAL.GetAllCourses().FirstOrDefault(x => x.CourseName.Equals(courseName));
            MajorCoursesTbl majorCoursesToReturn = new MajorCoursesTbl();
            //The general data we already know except for the course code.
            majorCoursesToReturn.MajorCode = majorCode;
            majorCoursesToReturn.CourseTeacherCode = courseTeacherCode;
            majorCoursesToReturn.CourseStartYear = new DateTime(DateTime.Now.Year, 09, 01);
            majorCoursesToReturn.CourseGrade = courseGrade;

            if (coursesTbl != null)
            //This means that the course exists.
                majorCoursesToReturn.CourseCode = coursesTbl.CourseCode;
            else
            //This means that the course does not exist and it needs to be added.
            {
                coursesTbl = _coursesDAL.AddCourse(new CoursesTbl() { CourseName = courseName});
                majorCoursesToReturn.CourseCode = coursesTbl.CourseCode;
            }
            _DB.MajorCoursesTbls.Add(majorCoursesToReturn);
            _DB.SaveChanges();
            return majorCoursesToReturn;
        }
        #endregion

    }
}
