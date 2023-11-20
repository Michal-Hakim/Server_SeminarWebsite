using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SeminarWebsite.Classes
{
    public class AttendanceToTheCourse
    {
        public int SeminarCode { get; set; }
        public int MajorCode { get; set; }
        public List<short> ListStudentCodes { get; set; }
        public List<bool> ListAttendanceOfStudents { get; set; }
        public DateTime LessonDate { get; set; }
        public short LessonNumber { get; set; }

        #region C-tor
        public AttendanceToTheCourse(int seminarCode, int majorCode, List<short> listStudentCodes, List<bool> listAttendanceOfStudents, DateTime lessonDate, short lessonNumber)
        {
            SeminarCode = seminarCode;
            MajorCode = majorCode;
            ListStudentCodes = listStudentCodes;
            ListAttendanceOfStudents = listAttendanceOfStudents;
            LessonDate = lessonDate;
            LessonNumber = lessonNumber;
        }
        #endregion

    }
}
