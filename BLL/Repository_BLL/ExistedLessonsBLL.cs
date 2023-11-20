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

namespace BLL.Repository_BLL
{
    public class ExistedLessonsBLL : IExistedLessonsBLL
    {
        static readonly IMapper _Mapper;

        #region C-tor static
        static ExistedLessonsBLL()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.AutoMapper>();
            });
            _Mapper = config.CreateMapper();
        }
        #endregion

        readonly IExistedLessonsDAL _existedLessonsDAL;

        #region C-tor public
        public ExistedLessonsBLL(IExistedLessonsDAL existedLessonsDAL)
        {
            _existedLessonsDAL = existedLessonsDAL;
        }
        #endregion

        //Get
        #region GetExistedLessonsByCourseCodeForTheMajor
        public ExistedLessonsDTO GetExistedLessonsByCourseCodeForTheMajor(short courseCodeForTheMajor)
        {
            ExistedLessonsTbl existedLessonsTbl = _existedLessonsDAL.GetExistedLessonsByCourseCodeForTheMajor(courseCodeForTheMajor);
            return _Mapper.Map<ExistedLessonsTbl, ExistedLessonsDTO>(existedLessonsTbl);
        }
        #endregion

        #region GetExistedLessonsByCourseCode
        public List<ExistedLessonsDTO> GetExistedLessonsByCourseCode(short courseCode)
        {
            List<ExistedLessonsDTO> existedLessonsDTO = new List<ExistedLessonsDTO>();
            _existedLessonsDAL.GetExistedLessonsByCourseCode(courseCode).ForEach(
                x => existedLessonsDTO.Add(_Mapper.Map<ExistedLessonsTbl, ExistedLessonsDTO>(x)));
            return existedLessonsDTO;
        }
        #endregion

        //Put

        //Post

        //Delete

    }
}
