using DAL.Interfaces;
using DAL.Models;
using DTO.Repository_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICoursesBLL
    {
        //Get
        public CoursesDTO GetCoursesByByCourseCode(short courseCode);
        public CoursesDTO GetCoursesByCourseCode(short courseCode);
        public List<CoursesDTO> GetCoursesByMajorCode(short majorCode);
        public List<CoursesDTO> GetCoursesByMajorCodeAndCourseGrade(short majorCode, string courseGrade);
        //public List<CoursesDTO> GetAllCoursesByMajorCodeAndByCourseGrade(short majorCode, string courseGrade);

        //public CoursesDTO GetCoursesBySeminarCodeAndCourseName(short seminarCode, string courseName);
        //public List<CoursesDTO> GetAllCoursesByCourseTeacherCode(short courseTeacherCode);
        //public List<CoursesDTO> GetAllCoursesBySeminarCode(short seminarCode);
        //public List<CoursesDTO> GetAllCourses();

        //Put
        //public List<CoursesDTO> UpdateCourseByCourseCode(short courseCode);
        //public List<CoursesDTO> UpdateCourseBySeminarCodeAndCourseName(short seminarCode, string courseName);

        //Post
        public CoursesDTO AddCourse(CoursesDTO coursesDTO);

        //Delete
        //public List<CoursesDTO> DeleteCourseByCourseCode(short courseCode);
        //public List<CoursesDTO> DeleteCourseBySeminarCodeAndCourseName(short seminarCode, string courseName);
    }
}
