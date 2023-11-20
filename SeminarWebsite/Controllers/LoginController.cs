using BLL.Interfaces;
using DTO.Repository_DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SeminarWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IStaffBLL _staffBLL;
        private readonly IUserBLL _userBLL;
        private readonly ISeminarBLL _seminarBLL;

        #region C-tor
        public LoginController(IStaffBLL staffBLL, IUserBLL userBLL, ISeminarBLL seminarBLL)
        {  
            _seminarBLL = seminarBLL;
            _staffBLL = staffBLL;
            _userBLL = userBLL;
        }
        #endregion


        //Get
        #region LoginToTheSystem
        [HttpGet("LoginToTheSystem/{password}/{seminarCode}/{identificationNumber}")]
        public IActionResult LoginToTheSystem(string password, int seminarCode, string identificationNumber = "")
        {
            bool flag = false;
            int codeSeminar = 0;
            #region User (UserID, UserPassword, SeminarCode)
            UserDTO? userDTO = _userBLL.GetUserByUserID(identificationNumber);
            if (userDTO != null) 
            {
                StaffDTO? staffDTO = _staffBLL.GetStaffMemberByStaffID(identificationNumber);
                if(staffDTO != null) 
                    codeSeminar = staffDTO.SeminarCode;
                flag = userDTO.UserPassword.Equals(password) && codeSeminar.Equals(seminarCode);
            }
            if (flag)
                return Ok("1");
            #endregion

            #region Manager (SeminarName = "", SeminarManagerPassword, SeminarCode)
            SeminarDTO seminarDTO = _seminarBLL.GetSeminarBySeminarCode(seminarCode);
            flag = seminarDTO.SeminarManagerPassword.Equals(password);
            if (flag)
                return Ok("2");
            #endregion
            return Ok("0");
        }
        #endregion

        #region GetPassword
        [HttpGet("GetPassword")]
        public IActionResult GetPassword()
        {
            return Ok(PasswordLottery.PasswordLotteryFunction());
        }
        #endregion

        //Put

        //Post

        //Delete

    }
}
