using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions
{
    public class ExistedLessonsActions : IExistedLessonsDAL
    {
        readonly SeminarWebsiteContext _DB;
        readonly IMajorCoursesDAL _majorCoursesDAL;

        #region C-tor
        public ExistedLessonsActions(SeminarWebsiteContext DB, IMajorCoursesDAL majorCoursesDAL)
        {
            this._DB = DB;
            _majorCoursesDAL= majorCoursesDAL;
        }
        #endregion

        //Get
        #region GetAllExistedLessons
        public List<ExistedLessonsTbl> GetAllExistedLessons()
        {
            return _DB.ExistedLessonsTbls.ToList();
        }
        #endregion

        #region GetAllExistedLessonsByCourseCodeForTheMajor
        public ExistedLessonsTbl GetExistedLessonsByCourseCodeForTheMajor(short courseCodeForTheMajor)
        {
            List<ExistedLessonsTbl> List = _DB.ExistedLessonsTbls.Where(x => x.CourseCodeForTheMajor.Equals(courseCodeForTheMajor)).ToList();
            return List.OrderBy(x => x.LessonCode).Last();
        }
        #endregion

        #region GetAllExistedLessonsByLessonCodeAndLessonDate
        public List<ExistedLessonsTbl> GetAllExistedLessonsByLessonCodeAndLessonDate(short lessonCode, DateTime lessonDate)
        {
            return GetAllExistedLessonsByLessonDate(lessonDate).Where(x => x.LessonCode.Equals(lessonCode)).ToList();
        }
        #endregion

        #region GetAllExistedLessonsByLessonDate
        public List<ExistedLessonsTbl> GetAllExistedLessonsByLessonDate(DateTime lessonDate)
        {
            return _DB.ExistedLessonsTbls.Where(x => x.LessonDate.Equals(x.LessonDate)).ToList();
        }
        #endregion

        #region GetExistedLessonsByCourseCode
        public List<ExistedLessonsTbl> GetExistedLessonsByCourseCode(short courseCode)
        {
            List<ExistedLessonsTbl> existedLessonsTbl = new List<ExistedLessonsTbl>();
            foreach (ExistedLessonsTbl item in GetAllExistedLessons())
            {
                short courseCodeOfExistedLesson = _majorCoursesDAL.GetMajorCourseByCourseCodeForTheMajor(item.CourseCodeForTheMajor).CourseCode;
                if(courseCodeOfExistedLesson.Equals(courseCode))
                    existedLessonsTbl.Add(item);
            }
            return existedLessonsTbl;
        }
        #endregion

        //Put

        //Post
        #region AddExistedLesson
        public List<ExistedLessonsTbl> AddExistedLesson(ExistedLessonsTbl existedLessonsTbl)
        {
            _DB.ExistedLessonsTbls.Add(existedLessonsTbl);
            _DB.SaveChanges();
            return GetAllExistedLessons();
        }
        #endregion

        //Delete

    }
}
