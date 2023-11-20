using DAL.Models;
using DTO.Repository_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IExistedLessonsBLL
    {
        //Get
        public ExistedLessonsDTO GetExistedLessonsByCourseCodeForTheMajor(short courseCodeForTheMajor);
        public List<ExistedLessonsDTO> GetExistedLessonsByCourseCode(short courseCode);
        //public List<ExistedLessonsDTO> GetAllExistedLessons();
        //public List<ExistedLessonsDTO> GetAllExistedLessonsByLessonCodeAndLessonDate(short lessonCode, DateTime lessonDate);
        //public List<ExistedLessonsDTO> GetAllExistedLessonsByCourseCodeForTheMajorAndLessonDate(short courseCodeForTheMajor, DateTime lessonDate);
        //public List<ExistedLessonsDTO> GetAllExistedLessonsByLessonDate(DateTime lessonDate);

        //Put
        //public List<ExistedLessonsDTO> UpdateExistedLessonByLessonCode(short lessonCode);

        //Post
        //public List<ExistedLessonsDTO> AddExistedLesson(ExistedLessonsDTO existedLessonsDTO);

        //Delete
    }
}
