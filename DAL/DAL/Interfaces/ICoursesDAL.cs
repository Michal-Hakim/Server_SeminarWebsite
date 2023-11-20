using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICoursesDAL
    {
        //Get
        public List<CoursesTbl> GetAllCourses();
        public List<CoursesTbl> GetAllCoursesBySeminarCode(short seminarCode);
        public CoursesTbl GetCoursesByByCourseCode(short courseCode);
        public CoursesTbl GetCoursesBySeminarCodeAndCourseName(short seminarCode, string courseName);
        public List<CoursesTbl> GetAllCoursesByCourseTeacherCode(short courseTeacherCode);
        //public List<CoursesTbl> GetAllCoursesByMajorCodeAndByCourseGrade(short majorCode, string courseGrade);
        
        //Put
        //public List<CoursesTbl> UpdateCourseByCourseCode(short courseCode);
        //public List<CoursesTbl> UpdateCourseBySeminarCodeAndCourseName(short seminarCode, string courseName);

        //Post
        public CoursesTbl AddCourse(CoursesTbl coursesTbl);

        //Delete
        public List<CoursesTbl> DeleteCourseByCourseCode(short courseCode);
        public List<CoursesTbl> DeleteCourseBySeminarCodeAndCourseName(short seminarCode, string courseName);
    }
}
