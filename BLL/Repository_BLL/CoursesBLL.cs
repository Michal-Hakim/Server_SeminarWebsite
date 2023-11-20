using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO.Repository_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository_BLL
{
    public class CoursesBLL : ICoursesBLL
    {
        static readonly IMapper _Mapper;

        #region C-tor static
        static CoursesBLL()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.AutoMapper>();
            });
            _Mapper = config.CreateMapper();
        }
        #endregion

        readonly ICoursesDAL _coursesDAL;
        readonly IMajorCoursesDAL _majorCourseDAL;

        #region C-tor public
        public CoursesBLL(ICoursesDAL coursesDAL, IMajorCoursesDAL majorCourseDAL)
        {
            _coursesDAL = coursesDAL;
            _majorCourseDAL = majorCourseDAL;
        }
        #endregion


        //Get
        #region GetCoursesByByCourseCode
        public CoursesDTO GetCoursesByByCourseCode(short courseCode)
        {
            return _Mapper.Map<CoursesTbl, CoursesDTO>(_coursesDAL.GetCoursesByByCourseCode(courseCode));
        }
        #endregion

        #region GetCoursesByCourseCode
        public CoursesDTO GetCoursesByCourseCode(short courseCode)
        {
            CoursesTbl coursesTbls = _coursesDAL.GetCoursesByByCourseCode(courseCode);
            CoursesDTO coursesDTOs = _Mapper.Map<CoursesTbl, CoursesDTO>(coursesTbls);
            return coursesDTOs;
        }
        #endregion

        #region GetCoursesByMajorCode
        public List<CoursesDTO> GetCoursesByMajorCode(short majorCode)
        {
            List<CoursesDTO> majorDTO = new List<CoursesDTO>();
            List<MajorCoursesDTO> majorCoursesDTO = new List<MajorCoursesDTO>();
            _majorCourseDAL.GetMajorCoursesByMajorCode(majorCode).ForEach(x => majorCoursesDTO.Add(_Mapper.Map<MajorCoursesTbl, MajorCoursesDTO>(x)));
            foreach (MajorCoursesDTO item in majorCoursesDTO)
            {
                CoursesDTO c = GetCoursesByCourseCode(item.CourseCode);
                if (c != null)
                    majorDTO.Add(c);
            }
            return majorDTO;
        }
        #endregion

        #region GetCoursesByMajorCodeAndCourseGrade
        public List<CoursesDTO> GetCoursesByMajorCodeAndCourseGrade(short majorCode, string courseGrade)
        {
            List<CoursesDTO> majorDTO = new List<CoursesDTO>();
            List<MajorCoursesDTO> majorCoursesDTO = new List<MajorCoursesDTO>();
            _majorCourseDAL.GetMajorCoursesByMajorCodeAndByCourseGrade(majorCode, courseGrade).ForEach(x => majorCoursesDTO.Add(_Mapper.Map<MajorCoursesTbl, MajorCoursesDTO>(x)));
            foreach (MajorCoursesDTO item in majorCoursesDTO)
            {
                CoursesDTO c = GetCoursesByCourseCode(item.CourseCode);
                if (c != null)
                    majorDTO.Add(c);
            }
            return majorDTO;
        }
        #endregion

        //#region GetAllCoursesByMajorCodeAndByCourseGrade
        //public List<CoursesDTO> GetAllCoursesByMajorCodeAndByCourseGrade(short majorCode, string courseGrade)
        //{
        //    List<CoursesDTO> coursesDTOs= new List<CoursesDTO>();
        //    _coursesDAL.GetAllCoursesByMajorCodeAndByCourseGrade(majorCode, courseGrade).ForEach(x => coursesDTOs.Add(_Mapper.Map<CoursesTbl, CoursesDTO>(x)));
        //    return coursesDTOs;
        //}
        //#endregion
        
        //Put

        //Post
        #region AddCourse
        public CoursesDTO AddCourse(CoursesDTO coursesDTO)
        {
            return _Mapper.Map<CoursesTbl,CoursesDTO>(_coursesDAL.AddCourse(_Mapper.Map<CoursesDTO, CoursesTbl>(coursesDTO)));
        }
        #endregion
        //Delete
    }
}
