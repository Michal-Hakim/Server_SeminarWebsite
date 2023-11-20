using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL.Actions
{
    public class AttendencePerCourseActions : IAttendencePerCourseDAL
    {
        readonly SeminarWebsiteContext _DB;
        readonly IExistedLessonsDAL _existedLessonsDAL;

        #region C-tor
        public AttendencePerCourseActions(SeminarWebsiteContext DB, IExistedLessonsDAL existedLessonsDAL)
        {
            this._DB = DB;
            _existedLessonsDAL = existedLessonsDAL;
        }
        #endregion

        #region Nested Class
        public class AttendanceDetails
        {
            public DateTime Date { get; set; }
            public int LessonNumber { get; set; }
            public bool Attendance { get; set; }
        }
        #endregion

        //Get
        #region GetAllAttendencePerCourse
        public List<AttendencePerCourseTbl> GetAllAttendencePerCourse()
        {
            return _DB.AttendencePerCourseTbls.ToList();
        }
        #endregion

        #region GetAllStudentsByDate
        public List<AttendencePerCourseTbl> GetAllStudentsByDate(DateTime date)
        {
            List<short> listExistedLessons = (List<short>)_DB.ExistedLessonsTbls.Where(x => x.LessonDate.Equals(date)).GroupBy(x => x.LessonCode);
            List<AttendencePerCourseTbl> listAattendencePerCourses = new List<AttendencePerCourseTbl>();
            foreach (var item in _DB.AttendencePerCourseTbls)
            {
                if (listExistedLessons.IndexOf(item.LessonCode) != -1)
                    listAattendencePerCourses.Add(item);
            }
            return listAattendencePerCourses;
        }
        #endregion

        #region GetAllStudentsByLessonCode
        public List<AttendencePerCourseTbl> GetAllStudentsByLessonCode(short lessonCode)
        {
            return _DB.AttendencePerCourseTbls.Where(x => x.LessonCode.Equals(lessonCode)).ToList();
        }
        #endregion

        #region GetAttendenceForCourseByStudentCode
        public List<AttendencePerCourseTbl> GetAttendenceForCourseByStudentCode(short studentCode)
        {
            return _DB.AttendencePerCourseTbls.Where(x => x.StudentCode.Equals(studentCode)).ToList();
        }
        #endregion

        #region GetAttendenceForCourseByCourseCodeAndStudentCode
        public List<AttendencePerCourseTbl> GetAttendenceForCourseByCourseCodeAndStudentCode(short courseCode, short studentCode)
        {
            //רשימת הנוכחות של התלמידה - מכל השיעורים
            List<AttendencePerCourseTbl> attendencePerCourseTblByStudentCode = _DB.AttendencePerCourseTbls.Where(x => x.StudentCode.Equals(studentCode)).ToList();

            //רשימת הקודים של כל השיעורים שבהם התלמידה נכחה
            List<short> lessonCodes = new List<short>();
            attendencePerCourseTblByStudentCode.ForEach(x => lessonCodes.Add(x.LessonCode));

            //רשימת השיעורים בהם התלמידה נכחה
            List<ExistedLessonsTbl> existedLessonsTbls = new List<ExistedLessonsTbl>();
            foreach (ExistedLessonsTbl item in _DB.ExistedLessonsTbls.ToList())
            {
                bool isExistedLesson = lessonCodes.Contains(item.LessonCode);
                if (isExistedLesson)
                    existedLessonsTbls.Add(item);
            }

            //עבור הקורס עליו רוצים לעבוד CourseCodeForTheMajorרשימת ה 
            List<short> majorCourses = _DB.MajorCoursesTbls.Where(x => x.CourseCode.Equals(courseCode)).Select(x => x.CourseCodeForTheMajor).ToList();

            //כל השיעורים שהתקיימו עבור התלמידה לקורס המתאים
            //כל הקורסים שהיא צריכה להיות נוכחת בהם
            List<ExistedLessonsTbl> existedLessonsPerStudent = new List<ExistedLessonsTbl>();
            foreach (ExistedLessonsTbl item in existedLessonsTbls)
            {
                bool isExistedLesson = majorCourses.Contains(item.CourseCodeForTheMajor);
                if (isExistedLesson)
                    existedLessonsPerStudent.Add(item);
            }

            List<AttendencePerCourseTbl> attendencePerCoursePerStudent = new List<AttendencePerCourseTbl>();
            foreach (ExistedLessonsTbl item in existedLessonsPerStudent)
            {
                AttendencePerCourseTbl a = attendencePerCourseTblByStudentCode.FirstOrDefault(x => x.LessonCode.Equals(item.LessonCode));
                if (a != default)
                    attendencePerCoursePerStudent.Add(a);
            }

            return attendencePerCoursePerStudent;
        }
        #endregion

        #region GetTheAttendanceDetailsOfAStudentForAnyCourse
        public List<object> GetTheAttendanceDetailsOfAStudentForAnyCourse(short courseCode, short studentCode)
        {
            List<ExistedLessonsTbl> existedLessonsByCourseCode = _existedLessonsDAL.GetExistedLessonsByCourseCode(courseCode);
            List<AttendencePerCourseTbl> attendenceForCourseByStudentCode = GetAttendenceForCourseByStudentCode(studentCode);
            List<short> listOfLessonCodeFromAttendenceForCourseByStudentCode = attendenceForCourseByStudentCode.Select(x => x.LessonCode).ToList();

            List<AttendanceDetails> result = new List<AttendanceDetails>();
            foreach (ExistedLessonsTbl item in existedLessonsByCourseCode)
            {
                int index = listOfLessonCodeFromAttendenceForCourseByStudentCode.IndexOf(item.LessonCode);
                if(index != -1)
                    result.Add(new AttendanceDetails() { Date = (DateTime)item.LessonDate, LessonNumber = (int)item.LessonTime, Attendance = attendenceForCourseByStudentCode[index].StudentPresentInLesson });
                else
                    result.Add(new AttendanceDetails() { Date = (DateTime)item.LessonDate, LessonNumber = (int)item.LessonTime, Attendance = false });
            }
            result = result.OrderBy(x => x.LessonNumber).ThenBy(x => x.Date).ToList();
            
            List<object> resultOfTypeObject = new List<object>();
            result.ForEach(x => resultOfTypeObject.Add(x));
            return resultOfTypeObject;
        }
        #endregion

        #region GetTheNumberOfHoursAStudentHasAttendedACourse
        public int GetTheNumberOfHoursAStudentHasAttendedACourse(short courseCode, short studentCode)
        {
            List<ExistedLessonsTbl> existedLessonsByCourseCode = _existedLessonsDAL.GetExistedLessonsByCourseCode(courseCode);
            List<AttendencePerCourseTbl> attendenceForCourseByStudentCode = GetAttendenceForCourseByStudentCode(studentCode);
            List<short> listOfLessonCodeFromAttendenceForCourseByStudentCode = attendenceForCourseByStudentCode.Select(x => x.LessonCode).ToList();

            int count = 0;
            existedLessonsByCourseCode.ForEach(x =>
            {
                int index = listOfLessonCodeFromAttendenceForCourseByStudentCode.IndexOf(x.LessonCode);
                if (index != -1 && attendenceForCourseByStudentCode[index].StudentPresentInLesson)
                    count++;
            });
            return count;
        }
        #endregion
        
        //Put

        //Post
        #region AddAttendencePerCourse
        public List<AttendencePerCourseTbl> AddAttendencePerCourse(AttendencePerCourseTbl attendencePerCourseTbl)
        {
            _DB.AttendencePerCourseTbls.Add(attendencePerCourseTbl);
            _DB.SaveChanges();
            return GetAllAttendencePerCourse();
        }
        #endregion

        //Delete

    }
}
