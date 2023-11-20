using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions
{
    public class CoursesActions : ICoursesDAL
    {
        readonly SeminarWebsiteContext _DB;
        //readonly IMajorCoursesDAL _majorCoursesDAL;

        #region C-tor
        public CoursesActions(SeminarWebsiteContext DB)
        {
            this._DB = DB;
        }
        #endregion

        //Get
        #region GetAllCourses
        public List<CoursesTbl> GetAllCourses()
        {
            return _DB.CoursesTbls.ToList();
        }
        #endregion

        #region GetAllCoursesByCourseTeacherCode
        public List<CoursesTbl> GetAllCoursesByCourseTeacherCode(short courseTeacherCode)
        {
            List<MajorCoursesTbl> listOfCourseTeacherCode = _DB.MajorCoursesTbls.Where(x => x.CourseTeacherCode.Equals(courseTeacherCode)).ToList();
            List<CoursesTbl> listCoursesByTeacherCodeTbl = new List<CoursesTbl>();

            foreach (var item in listOfCourseTeacherCode)
            {
                CoursesTbl course = _DB.CoursesTbls.FirstOrDefault(x => item.CourseCode.Equals(x.CourseCode));
                if (course != null)
                    listCoursesByTeacherCodeTbl.Add(course);
            }
            _DB.SaveChanges();
            return listCoursesByTeacherCodeTbl.ToList();
        }
        #endregion

        #region GetAllCoursesBySeminarCode
        public List<CoursesTbl> GetAllCoursesBySeminarCode(short seminarCode)
        {
            List<short> listMajorTbl = (List<short>)_DB.MajorTbls.Where(x => x.SeminarCode.Equals(seminarCode)).GroupBy(x => x.MajorCode);
            List<short> listCoursesTbl = new List<short>();
            foreach (var item in _DB.MajorCoursesTbls)
            {
                if (listMajorTbl.IndexOf(item.MajorCode) != -1)
                    listCoursesTbl.Add(item.CourseCode);
            }

            listCoursesTbl.Distinct();

            List<CoursesTbl> coursesTbl = new List<CoursesTbl>();
            foreach (var item in _DB.CoursesTbls)
            {
                if (listCoursesTbl.IndexOf(item.CourseCode) != -1)
                    coursesTbl.Add(item);
            }
            return coursesTbl;
        }
        #endregion

        #region GetCoursesByByCourseCode
        public CoursesTbl GetCoursesByByCourseCode(short courseCode)
        {
            return _DB.CoursesTbls.FirstOrDefault(x => x.CourseCode.Equals(courseCode));
        }
        #endregion

        #region GetCoursesBySeminarCodeAndCourseName
        public CoursesTbl GetCoursesBySeminarCodeAndCourseName(short seminarCode, string courseName)
        {
            return GetAllCoursesBySeminarCode(seminarCode).FirstOrDefault(x => x.CourseName.Equals(courseName)) ?? null;
        }
        #endregion

        //#region GetAllCoursesByMajorCodeAndByCourseGrade
        //public List<CoursesTbl> GetAllCoursesByMajorCodeAndByCourseGrade(short majorCode, string courseGrade)
        //{
        //    List <MajorCoursesTbl> majorCoursesTbls = _majorCoursesDAL.GetMajorCoursesByMajorCodeAndByCourseGrade(majorCode, courseGrade);
        //    List <short> coursesCode = majorCoursesTbls.Select(x => x.CourseCode).Distinct().Order().ToList();
        //    List<CoursesTbl> coursesTbls = new List<CoursesTbl>();

        //    coursesCode.ForEach(x => coursesTbls.Add(GetCoursesByByCourseCode(x)));
        //    return coursesTbls;
        //}
        //#endregion

        //Put

        //Post
        #region AddCourse
        public CoursesTbl AddCourse(CoursesTbl coursesTbl)
        {
            _DB.CoursesTbls.Add(coursesTbl);
            _DB.SaveChanges();
            return _DB.CoursesTbls.Last();
        }
        #endregion

        //Delete
        #region DeleteCourseByCourseCode
        public List<CoursesTbl> DeleteCourseByCourseCode(short courseCode)
        {
            _DB.CoursesTbls.Remove(GetCoursesByByCourseCode(courseCode));
            _DB.SaveChanges();
            return GetAllCourses();
        }
        #endregion

        #region DeleteCourseBySeminarCodeAndCourseName
        public List<CoursesTbl> DeleteCourseBySeminarCodeAndCourseName(short seminarCode, string courseName)
        {
            _DB.CoursesTbls.Remove(GetCoursesBySeminarCodeAndCourseName(seminarCode, courseName));
            _DB.SaveChanges();
            return GetAllCourses();
        }
        #endregion

    }
}
