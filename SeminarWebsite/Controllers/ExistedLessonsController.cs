using BLL.Interfaces;
using DTO.Repository_DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SeminarWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExistedLessonsController : ControllerBase
    {
        private readonly IExistedLessonsBLL _existedLessonsBLL;

        #region C-tor
        public ExistedLessonsController(IExistedLessonsBLL existedLessonsBLL)
        {
            _existedLessonsBLL = existedLessonsBLL;
        }
        #endregion

        //Get
        #region GetExistedLessonsByCourseCodeForTheMajor
        [HttpGet("GetExistedLessonsByCourseCodeForTheMajor")]
        public ExistedLessonsDTO GetExistedLessonsByCourseCodeForTheMajor(short courseCodeForTheMajor)
        {
            return _existedLessonsBLL.GetExistedLessonsByCourseCodeForTheMajor(courseCodeForTheMajor);
        }
        #endregion
        
        //Put

        //Post

        //Delete

    }
}
