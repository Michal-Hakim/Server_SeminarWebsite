using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAttendencePerCourseDAL
    {
        //Get
        public int GetTheNumberOfHoursAStudentHasAttendedACourse(short courseCode, short studentCode);
        public List<AttendencePerCourseTbl> GetAllAttendencePerCourse();
        public List<AttendencePerCourseTbl> GetAllStudentsByLessonCode(short lessonCode);
        public List<AttendencePerCourseTbl> GetAllStudentsByDate(DateTime date);
        public List<AttendencePerCourseTbl> GetAttendenceForCourseByStudentCode(short studentCode);
        public List<AttendencePerCourseTbl> GetAttendenceForCourseByCourseCodeAndStudentCode(short courseCode, short studentCode);
        public List<object> GetTheAttendanceDetailsOfAStudentForAnyCourse(short courseCode, short studentCode);
        
        //Put
        //public List<AttendencePerCourseTbl> UpdateAttendenceForCourseByStudentCode(short studentCode);
        //public List<AttendencePerCourseTbl> UpdateAttendenceForCourseByStudentCodeAndLessonCode(short studentCode, short lessonCode);

        //Post 
        public List<AttendencePerCourseTbl> AddAttendencePerCourse(AttendencePerCourseTbl attendencePerCourseTbl);

        //Delete
    }
}
