using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;

namespace SeminarWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionsController : ControllerBase
    {
        //Get

        //Put

        //Post
        #region UploadFileExcel
        [HttpPost("UploadFileExcel")]
        public async Task<IActionResult> UploadFileExcel([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file was uploaded.");
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            //שליחה לפונקציית קריאה מקובץ XL עם הניתוב לתקיית wwwroot
            //functions.READExcel(fileName);

            //מחיקת קובץ ה-XL מתקיית wwwroot
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);

            return Ok(filePath);
        }
        #endregion

        //Delete

        
    }
}
