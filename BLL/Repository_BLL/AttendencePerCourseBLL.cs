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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLL.Repository_BLL
{
    public class AttendencePerCourseBLL : IAttendencePerCourseBLL
    {
        static readonly IMapper _Mapper;

        #region C-tor static
        static AttendencePerCourseBLL()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.AutoMapper>();
            });
            _Mapper = config.CreateMapper();
        }
        #endregion

        readonly IAttendencePerCourseDAL _attendencePerCourseDAL;
        readonly IMajorDAL _majorDAL;
        readonly IMajorCoursesDAL _majorCoursesDAL;
        readonly IExistedLessonsDAL _existedLessonsDAL;
        readonly IUserDAL _userDAL;
        readonly IStaffDAL _staffDAL;
        readonly ICoursesDAL _coursesDAL;

        #region C-tor public
        public AttendencePerCourseBLL(IAttendencePerCourseDAL attendencePerCourseDAL, IMajorDAL majorDAL, IMajorCoursesDAL majorCoursesDAL, IExistedLessonsDAL existedLessonsDAL, IUserDAL userDAL, IStaffDAL staffDAL, ICoursesDAL coursesDAL)
        {
            _attendencePerCourseDAL = attendencePerCourseDAL;
            _majorDAL = majorDAL;
            _majorCoursesDAL = majorCoursesDAL;
            _existedLessonsDAL = existedLessonsDAL;
            _userDAL = userDAL;
            _staffDAL = staffDAL;
            _coursesDAL = coursesDAL;
        }
        #endregion

        #region AddingAttendanceToTheCourse
        public void AddingAttendanceToTheCourse(int seminarCode, int majorCode, List<short> listStudentCodes, List<bool> listAttendanceOfStudents, DateTime lessonDate, short lessonNumber)
        {
            ExistedLessonsTbl existedLessons = new ExistedLessonsTbl();

            MajorCoursesTbl majorCourses = _majorCoursesDAL.GetMajorCoursesByMajorCode((short)majorCode).FirstOrDefault();

            existedLessons.CourseCodeForTheMajor = majorCourses.CourseCodeForTheMajor;
            existedLessons.LessonDate = lessonDate;
            existedLessons.LessonTime = lessonNumber;

            _existedLessonsDAL.AddExistedLesson(existedLessons);

            
            short lessonCode = _existedLessonsDAL.GetExistedLessonsByCourseCodeForTheMajor(majorCourses.CourseCodeForTheMajor).LessonCode;

            for (int i = 0; i < listStudentCodes.Count; i++)
            {
                AttendencePerCourseTbl attendencePerCourse = new AttendencePerCourseTbl();
                attendencePerCourse.LessonCode= lessonCode;
                attendencePerCourse.StudentPresentInLesson = listAttendanceOfStudents[i];
                attendencePerCourse.StudentCode = listStudentCodes[i];

                _attendencePerCourseDAL.AddAttendencePerCourse(attendencePerCourse);
            }
            
        }
        #endregion

        #region GetMoreDetailsForMajorByStudentCodeAndMajorCode
        public object GetMoreDetailsForMajorByStudentCodeAndMajorCode(short studentCode, short majorCode)
        {
            MajorTbl majorTbl = _majorDAL.GetMajorByMajorCode(majorCode);
            UserTbl userTbl = _userDAL.GetUserByUserID(_staffDAL.GetStaffMemberByStaffCode(majorTbl.MajorCodeCoordinator).StaffId);
            List<MajorCoursesTbl> majorCoursesTbl = _majorCoursesDAL.GetMajorCoursesByMajorCode(majorCode);

            var resultOfMajorCourses = from x in majorCoursesTbl
                                       select new
                                       {
                                           courseName = _coursesDAL.GetCoursesByByCourseCode(x.CourseCode).CourseName,
                                           courseTeacherFirstName = _userDAL.GetUserByUserID(_staffDAL.GetStaffMemberByStaffCode(x.CourseTeacherCode).StaffId).UserFirstName,
                                           courseTeacherLastName = _userDAL.GetUserByUserID(_staffDAL.GetStaffMemberByStaffCode(x.CourseTeacherCode).StaffId).UserLastName,
                                           numberOfHoursTheCourseTookPlace = _existedLessonsDAL.GetExistedLessonsByCourseCode(x.CourseCode).Count(),
                                           //numberOfHoursTheStudentAttendedTheCourse = GetAttendenceForCourseByCourseCodeAndStudentCode(x.CourseCode, studentCode).Count(x => x.StudentPresentInLesson),
                                           //detailOnTheStudentAttendedTheCourse = GetAttendenceForCourseByCourseCodeAndStudentCode(x.CourseCode, studentCode)
                                           numberOfHoursTheStudentAttendedTheCourse = _attendencePerCourseDAL.GetTheNumberOfHoursAStudentHasAttendedACourse(x.CourseCode,studentCode),
                                           detailOnTheStudentAttendedTheCourse = _attendencePerCourseDAL.GetTheAttendanceDetailsOfAStudentForAnyCourse(x.CourseCode, studentCode)
                                       };
            return resultOfMajorCourses;
        }
        #endregion

        //Get
        #region GetAttendenceForCourseByCourseCodeAndStudentCode
        public List<AttendencePerCourseDTO> GetAttendenceForCourseByCourseCodeAndStudentCode(short courseCode, short studentCode)
        {
            List<AttendencePerCourseDTO> attendencePerCourseDTO = new List<AttendencePerCourseDTO>();
            _attendencePerCourseDAL.GetAttendenceForCourseByCourseCodeAndStudentCode(courseCode, studentCode).ForEach(x =>
            attendencePerCourseDTO.Add(_Mapper.Map<AttendencePerCourseTbl, AttendencePerCourseDTO>(x)));
            return attendencePerCourseDTO;
        }
        #endregion

        //Put

        //Post

        //Delete
    }
}
