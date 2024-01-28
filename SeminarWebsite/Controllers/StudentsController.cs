using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO.Repository_DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeminarWebsite.Classes;
using SeminarWebsite.ExcelFiles;
using System.ComponentModel;
using System.Diagnostics;

namespace SeminarWebsite.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;
        private IConfiguration Configuration;
        private readonly IStudentsBLL _studentsBLL;
        private readonly IUserBLL _userBLL;
        private readonly ISeminarBLL _seminarBLL;
        private readonly IMajorBLL _majorBLL;
        private readonly IStaffBLL _staffBLL;
        private readonly ScheduledTask scheduledTask;

        #region C-tor
        public StudentsController(Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment, IConfiguration _configuration, IStudentsBLL studentsBLL, IUserBLL userBLL, ISeminarBLL seminarBLL, IMajorBLL majorBLL, IStaffBLL staffBLL)
        {
            Environment = _environment;
            Configuration = _configuration;
            _studentsBLL = studentsBLL;
            _userBLL = userBLL;
            _seminarBLL = seminarBLL;
            _majorBLL = majorBLL;
            _staffBLL = staffBLL;
            //scheduledTask = new ScheduledTask();
        }
        #endregion

        //Get
        #region GetFullStudentsData
        [HttpGet("GetFullStudentsDataBySeminarCode/{seminarCode}")]
        public List<FullStudentsData> GetFullStudentsDataBySeminarCode(short seminarCode)
        {
            List<FullStudentsData> fullStudentsDatas= new List<FullStudentsData>();
            List<StudentsDTO> listStudents = _studentsBLL.GetStudentsBySeminarCode(seminarCode);
            List<UserDTO> listUsers = _userBLL.GetAllUsers();
            List<string> listUserID = new List<string>();
            listUsers.ForEach(x => listUserID.Add(x.UserId));

            listStudents.ForEach(x =>
            {
                int index = listUserID.IndexOf(x.StudentId);
                if(index != -1)
                {
                    FullStudentsData fullStudent = new FullStudentsData();
                    fullStudent.UserId = listUsers[index].UserId;
                    fullStudent.UserPassword = listUsers[index].UserPassword;
                    fullStudent.UserFirstName = listUsers[index].UserFirstName;
                    fullStudent.UserLastName = listUsers[index].UserLastName;
                    fullStudent.UserHomePhoneNumber = listUsers[index].UserHomePhoneNumber;
                    fullStudent.UserCellPhoneNumber = listUsers[index].UserCellPhoneNumber;
                    fullStudent.UserHebrewDateOfBirth = listUsers[index].UserHebrewDateOfBirth;
                    fullStudent.UserEnglishDateOfBirth = listUsers[index].UserEnglishDateOfBirth;
                    fullStudent.UserAddress = listUsers[index].UserAddress;
                    fullStudent.UserLocationCity = listUsers[index].UserLocationCity;
                    fullStudent.StudentFatherCellPhoneNumber = x.StudentFatherCellPhoneNumber;
                    fullStudent.StudentMotherCellPhoneNumber = x.StudentMotherCellPhoneNumber;
                    fullStudent.SeminarName = _seminarBLL.GetSeminarBySeminarCode(x.SeminarCode).SeminarName;
                    fullStudent.StudentYearOfStartingSchool = x.StudentYearOfStartingSchool;
                    fullStudent.StudentGrade = x.StudentGrade;
                    fullStudent.StudentClassNumber = x.StudentClassNumber;
                    fullStudent.StudentFirstMajorName = x.StudentFirstMajorCode != null? _majorBLL.GetMajorByMajorCode((short)x.StudentFirstMajorCode).MajorName : "";
                    fullStudent.StudentSecondMajorName = x.StudentSecondMajorCode != null? _majorBLL.GetMajorByMajorCode((short)x.StudentSecondMajorCode).MajorName : "";
                    fullStudent.StudentLearnedFirstAid= x.StudentLearnedFirstAid;
                    fullStudent.StudentIsStudyingTeaching = x.StudentIsStudyingTeaching;
                    fullStudent.StudentTeachingGuideName = x.StudentTeachingGuideCode != null? _userBLL.GetUserByUserID(_staffBLL.GetStaffMemberByStaffCode((short)x.StudentTeachingGuideCode).StaffId).UserFirstName 
                                                           + " " 
                                                           + _userBLL.GetUserByUserID(_staffBLL.GetStaffMemberByStaffCode((short)x.StudentTeachingGuideCode).StaffId).UserLastName
                                                           :"";
                    fullStudentsDatas.Add(fullStudent);
                }
            });
            fullStudentsDatas = fullStudentsDatas.OrderBy(x => x.UserFirstName).ThenBy(x => x.UserLastName).ToList();
            return fullStudentsDatas;
        }
        #endregion

        #region GetAllStudentsByStudentMajorCode
        [HttpGet("GetAllStudentsByStudentMajorCode/{studentMajorCode}")]
        public IActionResult GetAllStudentsByStudentMajorCode(short studentMajorCode)
        {
            return Ok(_studentsBLL.GetAllStudentsByStudentMajorCode(studentMajorCode));
        }
        #endregion

        #region GetAllStudentsByStudentMajorCodeAndStudentGradeAndSeminarCode
        [HttpGet("GetAllStudentsByStudentMajorCodeAndStudentGradeAndSeminarCode/{studentMajorCode}/{studentGrade}/{seminarCode}")]
        public IActionResult GetAllStudentsByStudentMajorCodeAndStudentGradeAndSeminarCode(short studentMajorCode, short studentGrade, short seminarCode)
        {
            return Ok(_studentsBLL.GetAllStudentsByStudentMajorCodeAndStudentGradeAndSeminarCode(studentMajorCode, studentGrade, seminarCode));
        }
        #endregion

        #region GetStudentByStudentID
        [HttpGet("GetStudentByStudentID/{studentId}")]
        public IActionResult GetStudentByStudentID(string studentId)
        {
            return Ok(_studentsBLL.GetStudentByStudentID(studentId));
        }
        #endregion

        #region GetAllStudentsByStudentGradeAndSeminarCode
        [HttpGet("GetAllStudentsByStudentGradeAndSeminarCode/{studentGrade}/{seminarCode}")]
        public IActionResult GetAllStudentsByStudentGradeAndSeminarCode(string studentGrade, short seminarCode)
        {
            return Ok(_studentsBLL.GetAllStudentsByStudentGradeAndSeminarCode(studentGrade, seminarCode));
        }
        #endregion

        #region GetAllStudentsByStudentGradeAndStudentClassNumberAndSeminarCode
        [HttpGet("GetAllStudentsByStudentGradeAndStudentClassNumberAndSeminarCode/{studentGrade}/{studentClassNumber}/{seminarCode}")]
        public List<FullStudentsData> GetAllStudentsByStudentGradeAndStudentClassNumberAndSeminarCode(string studentGrade, short studentClassNumber, short seminarCode)
        {
            List<FullStudentsData> students = GetFullStudentsDataBySeminarCode(seminarCode);
            return students.Where(x => x.StudentGrade.Equals(studentGrade) && x.StudentClassNumber.Equals(studentClassNumber)).ToList();
        }
        #endregion

        #region GetTheMaxNumberOfClassesInSeminarByGradeAndSeminarCode
        [HttpGet("GetTheMaxNumberOfClassesInSeminarByGradeAndSeminarCode/{grade}/{seminarCode}")]
        public IActionResult GetTheMaxNumberOfClassesInSeminarByGradeAndSeminarCode(string grade, short seminarCode)
        {
            return Ok(_studentsBLL.GetAllStudentsByStudentGradeAndSeminarCode(grade, seminarCode).Max(x => x.StudentClassNumber) ?? 0);
        }
        #endregion

        #region GetTheMaxNumberOfClassesInSeminarBySeminarCode
        [HttpGet("GetTheMaxNumberOfClassesInSeminarBySeminarCode/{seminarCode}")]
        public IActionResult GetTheMaxNumberOfClassesInSeminarBySeminarCode(short seminarCode)
        {
            int a = _studentsBLL.GetAllStudentsByStudentGradeAndSeminarCode("A", seminarCode).Max(x => x.StudentClassNumber) ?? 0;
            int b = _studentsBLL.GetAllStudentsByStudentGradeAndSeminarCode("B", seminarCode).Max(x => x.StudentClassNumber) ?? 0;
            int c = _studentsBLL.GetAllStudentsByStudentGradeAndSeminarCode("C", seminarCode).Max(x => x.StudentClassNumber) ?? 0;
            return Ok(Math.Max(a, Math.Max(b, c)));
        }
        #endregion

        //Put
        #region MatchingStudentToMajors
        [HttpPut("MatchingStudentToMajors/{studentID}/{StudentFirstMajorCode}/{StudentSecondMajorCode}")]
        public IActionResult MatchingStudentToMajors(string studentID, short StudentFirstMajorCode, short StudentSecondMajorCode)
        {
            return Ok(_studentsBLL.MatchingStudentToMajors(studentID, StudentFirstMajorCode, StudentSecondMajorCode));
        }
        #endregion

        #region UpStudentGradeBySeminarCode
        [HttpPut("UpStudentGradeBySeminarCode/{seminarCode}")]
        public IActionResult UpStudentGradeBySeminarCode(short seminarCode)
        {
            return Ok(_studentsBLL.UpStudentGradeBySeminarCode(seminarCode));
        }

        #endregion

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

                ExcelFileOfStudents students = new ExcelFileOfStudents(seminarCode, excelFilePath, textFilePath);
                students.FillingDataInTheTable();
                List<StudentsDTO> listStudentsDTO= students.listStudentDTO;
                List<UserDTO> listUserDTO = students.listUserDTO;

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

                //Going over the Excel file, checking if there is a student whose ID already exists in the data structure.
                //If so - update the existing user to the new student's data.
                //If not - addition to the data structure.
                #region Examination
                List<string> existingStudentsId = _studentsBLL.GetStudentsBySeminarCode(seminarCode).Select(x => x.StudentId).ToList();
                bool DoesAStudentExist = false;
                foreach (StudentsDTO newStudent in listStudentsDTO)
                {
                    if (existingStudentsId.IndexOf(newStudent.StudentId) != -1)
                        DoesAStudentExist = true;
                    else
                        DoesAStudentExist = false;

                    if (DoesAStudentExist)
                        _studentsBLL.UpdateStudentByStudentID(newStudent.StudentId, newStudent);
                    else
                        _studentsBLL.AddStudent(newStudent);
                }
                #endregion
            }
        }
        #endregion

        //Delete

    }
}
