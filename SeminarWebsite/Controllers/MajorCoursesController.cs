using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SeminarWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorCoursesController : ControllerBase
    {
        private readonly IMajorCoursesBLL _majorCoursesBLL;

        #region C-tor
        public MajorCoursesController(IMajorCoursesBLL majorCoursesBLL)
        {
            _majorCoursesBLL = majorCoursesBLL;
        }
        #endregion

        //Get
        #region GetMajorCoursesTblByCourseTeacherCode
        [HttpGet("GetMajorCoursesTblByCourseTeacherCode/{courseTeacherCode}")]
        public IActionResult GetMajorCoursesTblByCourseTeacherCode(short courseTeacherCode)
        {
            return Ok(_majorCoursesBLL.GetMajorCoursesTblByCourseTeacherCode(courseTeacherCode));
        }
        #endregion

        #region GetMajorAndCourseBySeminarCodeAndStaffCode
        [HttpPost("GetMajorAndCourseBySeminarCodeAndStaffCode/{seminarCode}/{staffCode}")]
        public IActionResult GetMajorAndCourseBySeminarCodeAndStaffCode(short seminarCode, short staffCode)
        {
            return Ok(_majorCoursesBLL.GetMajorAndCourseBySeminarCodeAndStaffCode(seminarCode, staffCode));
        }
        #endregion

        #region GetMajorAndCourseBySeminarCodeAndMajorCode
        [HttpGet("GetMajorAndCourseBySeminarCodeAndMajorCode/{seminarCode}/{majorCode}")]
        public IActionResult GetMajorAndCourseBySeminarCodeAndMajorCode(short seminarCode, short majorCode)
        {
            return Ok(_majorCoursesBLL.GetMajorAndCourseBySeminarCodeAndMajorCode(seminarCode, majorCode));
        }
        #endregion

        #region GetMajorCoursesByMajorCode
        [HttpGet("GetMajorCoursesByMajorCode/{majorCode}")]
        public IActionResult GetMajorCoursesByMajorCode(short majorCode)
        {
            return Ok(_majorCoursesBLL.GetMajorCoursesByMajorCode(majorCode));
        }
        #endregion

        //Put

        //Post
        #region AddAMajorCoursesByMajorCodeAndCourseGradeAndCourseNameAndCourseTeacherCode
        [HttpPost("AddAMajorCoursesByMajorCodeAndCourseGradeAndCourseNameAndCourseTeacherCode/{majorCode}/{courseGrade}/{courseName}/{courseTeacherCode}")]
        public IActionResult AddAMajorCoursesByMajorCodeAndCourseGradeAndCourseNameAndCourseTeacherCode(short majorCode, string courseGrade, string courseName, short courseTeacherCode)
        {
            return Ok(_majorCoursesBLL.AddAMajorCoursesByMajorCodeAndCourseGradeAndCourseNameAndCourseTeacherCode(majorCode, courseGrade, courseName, courseTeacherCode));
        }
        #endregion
        
        //Delete

    }
}
