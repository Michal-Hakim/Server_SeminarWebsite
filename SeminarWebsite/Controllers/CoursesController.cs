using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SeminarWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesBLL _coursesBLL;

        #region C-tor
        public CoursesController(ICoursesBLL coursesBLL)
        {
            _coursesBLL = coursesBLL;
        }
        #endregion

        //Get
        #region GetCoursesByCourseCode
        [HttpGet("GetCoursesByCourseCode/{courseCode}")]
        public IActionResult GetCoursesByCourseCode(short courseCode)
        {
            return Ok(_coursesBLL.GetCoursesByCourseCode(courseCode));
        }
        #endregion

        #region GetCoursesByMajorCode
        [HttpGet("GetCoursesByMajorCode/{majorCode}")]
        public IActionResult GetCoursesByMajorCode(short majorCode)
        {
            return Ok(_coursesBLL.GetCoursesByMajorCode(majorCode));
        }
        #endregion

        #region GetCoursesByMajorCodeAndCourseGrade
        [HttpGet("GetCoursesByMajorCodeAndCourseGrade/{majorCode}/{courseGrade}")]
        public IActionResult GetCoursesByMajorCodeAndCourseGrade(short majorCode, string courseGrade)
        {
            return Ok(_coursesBLL.GetCoursesByMajorCodeAndCourseGrade(majorCode, courseGrade));
        }
        #endregion
        
        //Put

        //Post

        //Delete

    }
}
