using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO.Repository_DTO;
using BLL.Interfaces;

namespace SeminarWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeminarController : ControllerBase
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;
        private readonly ISeminarBLL _seminarBLL;

        #region C-tor
        public SeminarController(Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment, ISeminarBLL seminarBLL)
        {
            Environment = _environment;
            _seminarBLL = seminarBLL;
        }
        #endregion

        //Get
        #region GetAllSeminars
        [HttpGet("GetAllSeminars")]
        public IActionResult GetAllSeminars()
        {
            return Ok(_seminarBLL.GetAllSeminars());
        }
        #endregion

        #region GetSeminarBySeminarCode
        [HttpGet("GetSeminarBySeminarCode/{seminarCode}")]
        public IActionResult GetSeminarBySeminarCode(int seminarCode)
        {
            return Ok(_seminarBLL.GetSeminarBySeminarCode(seminarCode));
        }
        #endregion

        #region GetPasswordLottery
        [HttpGet("GetPasswordLottery")]
        public IActionResult passwordLottery()
        {
            return Ok(PasswordLottery.PasswordLotteryFunction());
        }
        #endregion

        //Put
        #region UpdateSeminar
        [HttpPut("UpdateSeminar/{code}")]
        public IActionResult UpdateSeminar(short code, [FromBody] SeminarDTO SeminarDTO)
        {
            return Ok(_seminarBLL.UpdateSeminar(code, SeminarDTO));
        }
        #endregion

        #region UploadALogo
        [HttpPost("UploadALogo")]
        public IActionResult UploadALogo([FromForm] IFormFile file)
        {
            if (file != null)
            {
                #region Create a Folder - "Logos".
                string pathDirectory = Path.Combine(this.Environment.WebRootPath, "Logos");
                if (!Directory.Exists(pathDirectory))
                {
                    Directory.CreateDirectory(pathDirectory);
                }
                #endregion

                string fileName = Path.GetFileName(file.FileName);
                string filePath = Path.Combine(pathDirectory, fileName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return Ok();
        }
        #endregion

        //Post
        #region AddSeminar
        [HttpPost("AddSeminar")]
        public IActionResult AddSeminar([FromBody] SeminarDTO SeminarDTO)
        {
            return Ok(_seminarBLL.AddSeminar(SeminarDTO));
        }
        #endregion

        //Delete
        #region DeleteSeminar
        [HttpDelete("DeleteSeminar")]
        public IActionResult DeleteSeminar([FromBody] short code)
        {
            return Ok(_seminarBLL.DeleteSeminar(code));
        }
        #endregion

    }
}
