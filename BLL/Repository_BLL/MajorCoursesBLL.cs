using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO.Repository_DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository_BLL
{
    public class MajorCoursesBLL : IMajorCoursesBLL
    {
        static readonly IMapper _Mapper;

        #region C-tor static
        static MajorCoursesBLL()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.AutoMapper>();
            });
            _Mapper = config.CreateMapper();
        }
        #endregion

        readonly IMajorCoursesDAL _majorCoursesDAL;
        readonly IMajorDAL _majorDAL;
        readonly ICoursesDAL _coursesDAL;
        readonly IStaffDAL _staffDAL;
        readonly IUserDAL _userDAL;

        #region C-tor public
        public MajorCoursesBLL(IMajorCoursesDAL majorCoursesDAL, IMajorDAL majorDAL, ICoursesDAL coursesDAL, IStaffDAL staffDAL, IUserDAL userDAL)
        {
            _majorCoursesDAL = majorCoursesDAL;
            _majorDAL = majorDAL;
            _coursesDAL = coursesDAL;
            _staffDAL = staffDAL;
            _userDAL = userDAL;
        }
        #endregion

        #region Nested Class
        public class DictionaryMajorCourses
        {
            public string MajorName { get; set; }
            public List<string> CoursesNames { get; set; }
        }
        #endregion

        //Get
        #region GetMajorCourseByCourseCodeForTheMajor
        public MajorCoursesDTO GetMajorCourseByCourseCodeForTheMajor(short courseCodeForTheMajor)
        {
            return _Mapper.Map<MajorCoursesTbl, MajorCoursesDTO>(_majorCoursesDAL.GetMajorCourseByCourseCodeForTheMajor(courseCodeForTheMajor));
        }
        #endregion

        #region GetMajorCoursesTblByCourseTeacherCode
        public List<MajorCoursesDTO> GetMajorCoursesTblByCourseTeacherCode(short courseTeacherCode)
        {
            List<MajorCoursesDTO> majorCourseDTO = new List<MajorCoursesDTO>();
            List<MajorCoursesTbl> majorCourseTblTomajorCourseDTO = _majorCoursesDAL.GetMajorCoursesTblByCourseTeacherCode(courseTeacherCode);

            foreach (MajorCoursesTbl item in majorCourseTblTomajorCourseDTO)
                majorCourseDTO.Add(_Mapper.Map<MajorCoursesTbl, MajorCoursesDTO>(item));

            return majorCourseDTO;
        }
        #endregion

        #region GetMajorAndCourseBySeminarCodeAndStaffCode
        public List<MajorCoursesDTO> GetMajorAndCourseBySeminarCodeAndStaffCode(short seminarCode, short staffCode)
        {
            List<MajorCoursesDTO> majorCourseDTO = new List<MajorCoursesDTO>();
            List<MajorCoursesTbl> majorCourseTblTomajorCourseDTO = _majorCoursesDAL.GetMajorAndCourseBySeminarCodeAndStaffCode(seminarCode, staffCode);

            foreach (MajorCoursesTbl item in majorCourseTblTomajorCourseDTO)
                majorCourseDTO.Add(_Mapper.Map<MajorCoursesTbl, MajorCoursesDTO>(item));

            return majorCourseDTO;
        }
        #endregion

        #region GetMajorAndCourseBySeminarCodeAndMajorCode
        public List<MajorCoursesDTO> GetMajorAndCourseBySeminarCodeAndMajorCode(short seminarCode, short majorCode)
        {
            List<MajorCoursesDTO> majorCourseDTO = new List<MajorCoursesDTO>();
            List<MajorCoursesTbl> majorCourseTblTomajorCourseDTO = _majorCoursesDAL.GetMajorAndCourseBySeminarCodeAndMajorCode(seminarCode, majorCode);

            foreach (MajorCoursesTbl item in majorCourseTblTomajorCourseDTO)
                majorCourseDTO.Add(_Mapper.Map<MajorCoursesTbl, MajorCoursesDTO>(item));

            return majorCourseDTO;
        }
        #endregion

        #region GetMajorCoursesByMajorCodeAndByCourseGrade
        public List<MajorCoursesDTO> GetMajorCoursesByMajorCodeAndByCourseGrade(short majorCode, string courseGrade)
        {
            List<MajorCoursesTbl> majorCoursesTbl = _majorCoursesDAL.GetMajorCoursesByMajorCodeAndByCourseGrade(majorCode, courseGrade);
            List<MajorCoursesDTO> majorCoursesDTO = new List<MajorCoursesDTO>();

            foreach (MajorCoursesTbl item in majorCoursesTbl)
            {
                majorCoursesDTO.Add(_Mapper.Map<MajorCoursesTbl, MajorCoursesDTO>(item));
            }
            return majorCoursesDTO;
        }
        #endregion

        #region GetMajorCoursesInTheFormOfADictionaryByMajorCode_courseNameAndCourseTeacherName
        public Dictionary<string, string> GetMajorCoursesInTheFormOfADictionaryByMajorCode_courseNameAndCourseTeacherName(short majorCode)
        {
            List<MajorCoursesDTO> majorCourses = GetMajorCoursesByMajorCode(majorCode);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (MajorCoursesDTO x in majorCourses)
            {
                CoursesTbl course = _coursesDAL.GetCoursesByByCourseCode(x.CourseCode);
                UserTbl teacher = _userDAL.GetUserByUserID(_staffDAL.GetStaffMemberByStaffCode(x.CourseTeacherCode).StaffId);
                dic.Add(course.CourseName, teacher.UserFirstName + " " + teacher.UserLastName);
            }
            return dic;
        }
        #endregion

        #region GetMajorCoursesInTheFormOfADictionaryByCourseTeacherCode_majorNameAndCourseName
        public List<object> GetMajorCoursesInTheFormOfADictionaryByCourseTeacherCode_majorNameAndCourseName(short courseTeacherCode)
        {
            List<DictionaryMajorCourses> dictionaryMajorCourses = new List<DictionaryMajorCourses>();
            List<MajorCoursesDTO> majorCoursesDTO = GetMajorCoursesTblByCourseTeacherCode(courseTeacherCode);
            List<short> majorsCodes = majorCoursesDTO.Select(x => x.MajorCode).Distinct().ToList();
            
            majorsCodes.ForEach(x =>
            {
                List<string> majorCoursesNames = new List<string>();
                majorCoursesDTO.Where(y => y.MajorCode.Equals(x)).Select(y => y.CourseCode).ToList().ForEach(y =>
                    majorCoursesNames.Add(_coursesDAL.GetCoursesByByCourseCode(y).CourseName)
                );

                dictionaryMajorCourses.Add(
                    new DictionaryMajorCourses { 
                        MajorName = _majorDAL.GetMajorByMajorCode(x).MajorName,
                        CoursesNames = majorCoursesNames.OrderBy(x=> x).ToList()
                    });
            });

            dictionaryMajorCourses = dictionaryMajorCourses.OrderBy(x => x.MajorName).ToList();
            List<object> list = new List<object>();
            dictionaryMajorCourses.ForEach(x => list.Add(x));
            return list;
        }
        #endregion

        #region GetMajorCoursesByMajorCode
        public List<MajorCoursesDTO> GetMajorCoursesByMajorCode(short majorCode)
        {
            List<MajorCoursesTbl> majorCoursesTbl = _majorCoursesDAL.GetMajorCoursesByMajorCode(majorCode);
            List<MajorCoursesDTO> majorCoursesDTO = new List<MajorCoursesDTO>();

            foreach (MajorCoursesTbl item in majorCoursesTbl)
            {
                majorCoursesDTO.Add(_Mapper.Map<MajorCoursesTbl, MajorCoursesDTO>(item));
            }
            return majorCoursesDTO;
        }
        #endregion

        //Post
        #region AddAMajorCoursesByMajorCodeAndCourseGradeAndCourseNameAndCourseTeacherCode
        public MajorCoursesDTO AddAMajorCoursesByMajorCodeAndCourseGradeAndCourseNameAndCourseTeacherCode(short majorCode, string courseGrade, string courseName, short courseTeacherCode)
        {
            return _Mapper.Map<MajorCoursesTbl, MajorCoursesDTO>(_majorCoursesDAL.AddAMajorCoursesByMajorCodeAndCourseGradeAndCourseNameAndCourseTeacherCode(majorCode, courseGrade, courseName, courseTeacherCode));
        }
        #endregion
    }
}
