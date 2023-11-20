using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SeminarWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserBLL _userBLL;
        
        #region C-tor
        public UserController(IUserBLL userBLL)
        {
            _userBLL = userBLL;
        }
        #endregion

        //Get
        #region GetUserByUserID
        [HttpGet("GetUserByUserID/{userID}")]
        public IActionResult GetUserByUserID(string userID)
        {
            return Ok(_userBLL.GetUserByUserID(userID));
        }
        #endregion

        #region GetUsersByUserIDAndMajorCode
        [HttpGet("GetUsersByUserIDAndMajorCode/{majorCode}")]
        public IActionResult GetUsersByUserIDAndMajorCode(short majorCode)
        {
            return Ok(_userBLL.GetUsersByUserIDAndMajorCode(majorCode));
        }
        #endregion

        //Put

        //Post

        //Delete

    }
}
