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
    public interface IAttendencePerCourseBLL
    {
        public void AddingAttendanceToTheCourse(int seminarCode, int majorCode, List<short>  listStudentCodes, List<bool> listAttendanceOfStudents, DateTime lessonDate, short lessonNumber);
        public object GetMoreDetailsForMajorByStudentCodeAndMajorCode(short studentCode, short majorCode);

        //Get
        public List<AttendencePerCourseDTO> GetAttendenceForCourseByCourseCodeAndStudentCode(short courseCode, short studentCode);
        //public List<AttendencePerCourseDTO> GetAllAttendencePerCourse();
        //public List<AttendencePerCourseDTO> GetAllStudentsByLessonCode(short lessonCode);
        //public List<AttendencePerCourseDTO> GetAllStudentsByDate(DateTime date);
        //public List<AttendencePerCourseDTO> GetAttendenceForCourseByStudentCode(short studentCode);

        //Put
        //public List<AttendencePerCourseDTO> UpdateAttendenceForCourseByStudentCode(short studentCode);
        //public List<AttendencePerCourseDTO> UpdateAttendenceForCourseByStudentCodeAndLessonCode(short studentCode, short lessonCode);

        //Post 
        //public List<AttendencePerCourseDTO> AddAttendencePerCourse(AttendencePerCourseDTO attendencePerCourseDTO);

        //Delete
    }
}
