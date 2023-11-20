using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IExistedLessonsDAL
    {
        //Get
        public List<ExistedLessonsTbl> GetAllExistedLessons();
        public ExistedLessonsTbl GetExistedLessonsByCourseCodeForTheMajor(short courseCodeForTheMajor);
        public List<ExistedLessonsTbl> GetAllExistedLessonsByLessonCodeAndLessonDate(short lessonCode, DateTime lessonDate);
        public List<ExistedLessonsTbl> GetAllExistedLessonsByLessonDate(DateTime lessonDate);
        public List<ExistedLessonsTbl> GetExistedLessonsByCourseCode(short courseCode);

        //Put
        //public List<ExistedLessonsTbl> UpdateExistedLessonByLessonCode(short lessonCode);

        //Post
        public List<ExistedLessonsTbl> AddExistedLesson(ExistedLessonsTbl existedLessonsTbl);

        //Delete
    }
}
