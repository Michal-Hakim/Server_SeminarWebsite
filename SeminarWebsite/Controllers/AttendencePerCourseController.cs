using BLL.Interfaces;
using BLL.Repository_BLL;
using DTO.Repository_DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeminarWebsite.Classes;
using System.Security.AccessControl;

namespace SeminarWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendencePerCourseController : ControllerBase
    {
        private readonly IAttendencePerCourseBLL _attendencePerCourseBLL;
        private readonly IStudentsBLL _studentsBLL;
        private readonly IUserBLL _userBLL;
        private readonly IMajorBLL _majorBLL;
        
        #region C-tor
        public AttendencePerCourseController(IAttendencePerCourseBLL attendencePerCourseBLL, IStudentsBLL studentsBLL, IUserBLL userBLL, IMajorBLL majorBLL)
        {
            _attendencePerCourseBLL = attendencePerCourseBLL;
            _studentsBLL = studentsBLL;
            _userBLL = userBLL;
            _majorBLL = majorBLL;
        }
        #endregion

        //Get
        #region GetTheAttendanceForAllStudentsWithMoreDetailsBySeminarCode
        [HttpGet("GetTheAttendanceForAllStudentsWithMoreDetailsBySeminarCode/{seminarCode}")]
        public IActionResult GetTheAttendanceForAllStudentsWithMoreDetailsBySeminarCode(short seminarCode)
        {
            List<StudentsDTO> StudentsDTO = _studentsBLL.GetStudentsBySeminarCode(seminarCode);
            var result = from x in StudentsDTO
                         select new
                         {
                            studentFirstName = _userBLL.GetUserByUserID(x.StudentId).UserFirstName,
                            studentLastName = _userBLL.GetUserByUserID(x.StudentId).UserLastName,
                            studentGrade = x.StudentGrade,
                            firstMajorName = x.StudentFirstMajorCode != null? _majorBLL.GetMajorByMajorCode((short)x.StudentFirstMajorCode).MajorName : "",
                            detailsForTheFirstMajor = x.StudentFirstMajorCode != null ? _attendencePerCourseBLL.GetMoreDetailsForMajorByStudentCodeAndMajorCode(x.StudentCode, (short)x.StudentFirstMajorCode) : new List<object>(),
                            secondMajorName = x.StudentSecondMajorCode != null? _majorBLL.GetMajorByMajorCode((short)x.StudentSecondMajorCode).MajorName : "",
                            detailsForTheSecondMajor =  x.StudentSecondMajorCode != null? _attendencePerCourseBLL.GetMoreDetailsForMajorByStudentCodeAndMajorCode(x.StudentCode, (short)x.StudentSecondMajorCode) : new List<object>()
                         };
            return Ok(result);
        }
        #endregion

        //Put

        //Post
        #region AddingAttendanceToTheCourse
        [HttpPost("AddingAttendanceToTheCourse")]
        public void AddingAttendanceToTheCourse([FromBody] AttendanceToTheCourse attendance)
        {
            _attendencePerCourseBLL.AddingAttendanceToTheCourse(
                attendance.SeminarCode,
                attendance.MajorCode,
                attendance.ListStudentCodes,
                attendance.ListAttendanceOfStudents,
                attendance.LessonDate, //DateTime.Today, //
                attendance.LessonNumber);
        }
        #endregion

        //Delete

        

        
    }

}
