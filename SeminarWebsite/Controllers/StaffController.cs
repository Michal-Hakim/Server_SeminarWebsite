using BLL.Interfaces;
using DTO.Repository_DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Office.Interop.Excel;
using SeminarWebsite.Classes;
using SeminarWebsite.ExcelFiles;
using System.Runtime.Intrinsics.X86;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SeminarWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;
        private IConfiguration Configuration;
        private readonly IStaffBLL _staffBLL;
        private readonly IUserBLL _userBLL;
        private readonly IMajorCoursesBLL _majorCoursesBLL;

        #region C-tor
        public StaffController(Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment, IConfiguration _configuration, IStaffBLL staffBLL, IUserBLL userBLL, IMajorCoursesBLL majorCoursesBLL)
        {
            Environment = _environment;
            Configuration = _configuration;
            _staffBLL = staffBLL;
            _userBLL = userBLL;
            _majorCoursesBLL = majorCoursesBLL;
        }
        #endregion

        //Get
        #region GetStaffMemberByStaffID
        [HttpGet("GetStaffMemberByStaffID/{staffID}")]
        public IActionResult GetStaffMemberByStaffID(string staffID)
        {
            return Ok(_staffBLL.GetStaffMemberByStaffID(staffID));
        }
        #endregion

        #region GetFullStaffDataBySeminarCode
        [HttpGet("GetFullStaffDataBySeminarCode/{seminarCode}")]
        public List<FullStaffData> GetFullStaffDataBySeminarCode(short seminarCode)
        {
            List<FullStaffData> fullStaffDatas = new List<FullStaffData>();

            List<StaffDTO> staffDTO = _staffBLL.GetAllStaffBySeminarCode(seminarCode);
            UserDTO userDTO;

            foreach (StaffDTO item in staffDTO)
            {
                userDTO = _userBLL.GetUserByUserID(item.StaffId);
                fullStaffDatas.Add(new FullStaffData
                {
                    UserId = item.StaffId,
                    UserPassword = userDTO.UserPassword,
                    UserFirstName = userDTO.UserFirstName,
                    UserLastName = userDTO.UserLastName,
                    UserHomePhoneNumber = userDTO.UserHomePhoneNumber,
                    UserCellPhoneNumber = userDTO.UserCellPhoneNumber,
                    UserHebrewDateOfBirth = userDTO.UserHebrewDateOfBirth,
                    UserEnglishDateOfBirth = userDTO.UserEnglishDateOfBirth,
                    UserAddress = userDTO.UserAddress,
                    UserLocationCity = userDTO.UserLocationCity,
                    StaffCode = item.StaffCode,
                    StaffMemberPosition = item.StaffMemberPosition,
                    StaffEmploymentStartDate = item.StaffEmploymentStartDate,
                    StaffStatus = item.StaffStatus,
                    SeminarCode = item.SeminarCode
                });
            }
            fullStaffDatas = fullStaffDatas.OrderBy(x => x.UserFirstName).ThenBy(x => x.UserLastName).ToList();
            return fullStaffDatas;
        }
        #endregion

        #region GetTheStaffMemberWithMoreDetailsBySeminarCode
        [HttpGet("GetTheStaffMemberWithMoreDetailsBySeminarCode/{seminarCode}")]
        public IActionResult GetTheStaffMemberWithMoreDetailsBySeminarCode(short seminarCode)
        {
            List<StaffDTO> StaffDTO = _staffBLL.GetAllStaffBySeminarCode(seminarCode);

            var result = from x in StaffDTO
                         let staff = GetFullStaffDataBySeminarCode(seminarCode).FirstOrDefault(item => item.UserId.Equals(x.StaffId))
                         select new
                         {
                             userId = staff.UserId,
                             userPassword = staff.UserPassword,
                             userFirstName = staff.UserFirstName,
                             userLastName = staff.UserLastName,
                             userHomePhoneNumber = staff.UserHomePhoneNumber,
                             userCellPhoneNumber = staff.UserCellPhoneNumber,
                             userHebrewDateOfBirth = staff.UserHebrewDateOfBirth,
                             userEnglishDateOfBirth = staff.UserEnglishDateOfBirth,
                             userAddress = staff.UserAddress,
                             userLocationCity = staff.UserLocationCity,
                             staffCode = staff.StaffCode,
                             staffMemberPosition = staff.StaffMemberPosition,
                             staffEmploymentStartDate = staff.StaffEmploymentStartDate,
                             staffStatus = staff.StaffStatus,
                             seminarCode = staff.SeminarCode,
                             majorCourses = _majorCoursesBLL.GetMajorCoursesInTheFormOfADictionaryByCourseTeacherCode_majorNameAndCourseName(x.StaffCode)
                         };
            return Ok(result);
        }
        #endregion

        //Put

        //Post
        #region UploadFileExcel
        [HttpPost("UploadFileExcel/{seminarCode}")]
        public async void UploadFileExcel(short seminarCode, [FromForm] IFormFile file)
        {
            if (file != null)
            {
                #region Create a Folder - "Uploads".
                string pathDirectory = Path.Combine(this.Environment.WebRootPath, "Uploads");
                if (!Directory.Exists(pathDirectory))
                {
                    Directory.CreateDirectory(pathDirectory);
                }
                #endregion
                file.UploadAnExcelFileToTheWwwrootFolder(pathDirectory);
                string pathToWwwrootFolder = Path.Combine(this.Environment.WebRootPath, "Uploads");
                string excelFileName = Path.GetFileName(file.FileName);
                string excelFilePath = Path.Combine(pathToWwwrootFolder, excelFileName);
                string textFilePath = $"{pathToWwwrootFolder}\\{Path.GetFileNameWithoutExtension(excelFileName)}.txt";
                excelFilePath.ConvertAnExcelFileToATextFile(textFilePath);

                ExcelFileOfStaffMembers staffMembers = new ExcelFileOfStaffMembers(seminarCode, excelFilePath, textFilePath);
                staffMembers.FillingDataInTheTable();
                List<StaffDTO> listStaffDTO = staffMembers.listStaffDTO;
                List<UserDTO> listUserDTO = staffMembers.listUserDTO;

                //Going over the Excel file, checking if there is a user whose ID already exists in the data structure.
                //If so - update the existing user to the new user's data.
                //If not - addition to the data structure.
                #region Examination
                List<string> existingUsersId = _userBLL.GetAllUsers().Select(x => x.UserId).ToList();
                bool DoesAUserExist = false;
                foreach (UserDTO newUser in listUserDTO)
                {
                    if (existingUsersId.IndexOf(newUser.UserId) != -1) 
                        DoesAUserExist = true;
                    else
                    DoesAUserExist = false;

                    if (DoesAUserExist)
                        _userBLL.UpdateUserByUserID(newUser.UserId, newUser);
                    else
                        _userBLL.AddUser(newUser);
                }
                #endregion

                //Going over the Excel file, checking if there is a staff whose ID already exists in the data structure.
                //If so - update the existing user to the new staff's data.
                //If not - addition to the data structure.
                #region Examination
                List<string> existingStaffsId = _staffBLL.GetAllStaffBySeminarCode(seminarCode).Select(x => x.StaffId).ToList();
                bool DoesAStaffExist = false;
                foreach (StaffDTO newStaff in listStaffDTO)
                {
                    if (existingStaffsId.IndexOf(newStaff.StaffId) != -1)
                        DoesAStaffExist = true;
                    else
                        DoesAStaffExist = false;

                    if (DoesAStaffExist)
                        _staffBLL.UpdateStaffMemberByStaffID(newStaff.StaffId, newStaff);
                    else
                        _staffBLL.AddStaffMember(newStaff);
                }
                #endregion
            }

        }
        #endregion

        #region AddStaffMember
        [HttpPost("AddStaffMember")]
        public IActionResult AddStaffMember([FromBody] StaffDTO staffDTO)
        {
            return Ok(_staffBLL.AddStaffMember(staffDTO));
        }
        #endregion

        //Delete

    }
}
