using BLL.Interfaces;
using DTO.Repository_DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SeminarWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorController : ControllerBase
    {
        private readonly IMajorBLL _majorBLL;
        private readonly IUserBLL _userBLL;
        private readonly IStaffBLL _staffBLL;
        private readonly IMajorCoursesBLL _majorCoursesBLL;

        #region C-tor
        public MajorController(IMajorBLL majorBLL, IUserBLL userBLL, IStaffBLL staffBLL, IMajorCoursesBLL majorCoursesBLL)
        {
            _majorBLL = majorBLL;
            _userBLL = userBLL;
            _staffBLL= staffBLL;
            _majorCoursesBLL= majorCoursesBLL;
        }
        #endregion

        //Get

        #region GetAllMajors
        [HttpGet("GetAllMajors")]
        public IActionResult GetAllMajors()
        {
            return Ok(_majorBLL.GetAllMajors());
        }
        #endregion

        #region GetTheMajorsWithMoreDetailsBySeminarCode
        [HttpGet("GetTheMajorsWithMoreDetailsBySeminarCode/{seminarCode}")]
        public IActionResult GetTheMajorsWithMoreDetailsBySeminarCode(short seminarCode)
        {
            List<MajorDTO> listMajorDTO = _majorBLL.GetMajorBySeminarCode(seminarCode);

            var result = from x in listMajorDTO
                         let coordinator = _userBLL.GetUserByUserID(_staffBLL.GetStaffMemberByStaffCode(x.MajorCodeCoordinator).StaffId)
                         let coursesDictionary = new Dictionary<string, string>()
                         select new
                         {
                             x.MajorName,
                             nameCoordinator = coordinator.UserFirstName + " " + coordinator.UserLastName,
                             homePhoneNumberCoordinator = coordinator.UserHomePhoneNumber,
                             cellPhoneNumberCoordinator = coordinator.UserCellPhoneNumber,
                             coursesInMajor = _majorCoursesBLL.GetMajorCoursesInTheFormOfADictionaryByMajorCode_courseNameAndCourseTeacherName(x.MajorCode)
                         };
            return Ok(result);
        }
        #endregion

        #region GetMajorByMajorCode
        [HttpGet("GetMajorByMajorCode/{majorCode}")]
        public IActionResult GetMajorByMajorCode(short majorCode)
        {
            return Ok(_majorBLL.GetMajorByMajorCode(majorCode));
        }
        #endregion

        #region GetMajorsBySeminarAndTeacherCode
        [HttpGet("GetMajorsBySeminarAndTeacherCode/{seminarCode}/{staffCode}")]
        public IActionResult GetMajorsBySeminarAndTeacherCode(short seminarCode, short staffCode)
        {
            return Ok(_majorBLL.GetMajorsBySeminarAndTeacherCode(seminarCode, staffCode));
        }
        #endregion

        #region GetMajorBySeminarCodeAndMajorCode
        [HttpGet("GetMajorBySeminarCodeAndMajorCode/{seminarCode}/{majorCode}")]
        public IActionResult GetMajorBySeminarCodeAndMajorCode(short seminarCode, short majorCode)
        {
            return Ok(_majorBLL.GetMajorBySeminarCodeAndMajorCode(seminarCode, majorCode));
        }
        #endregion

        #region GetMajorBySeminarCode
        [HttpGet("GetMajorBySeminarCode/{seminarCode}")]
        public IActionResult GetMajorBySeminarCode(short seminarCode)
        {
            return Ok(_majorBLL.GetMajorBySeminarCode(seminarCode));
        }
        #endregion

        //Put

        //Post
        #region AddMajor
        [HttpPost("AddMajor")]
        public IActionResult AddMajor([FromBody] MajorDTO majorDTO)
        {
            return Ok(_majorBLL.AddMajor(majorDTO));
        }
        #endregion

        //Delete

    }
}
