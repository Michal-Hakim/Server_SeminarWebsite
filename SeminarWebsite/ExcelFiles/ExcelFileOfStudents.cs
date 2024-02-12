using DTO.Repository_DTO;
using System.Text;

namespace SeminarWebsite.ExcelFiles
{
    public class ExcelFileOfStudents
    {
        #region Fields
        public short SeminarCode { get; set; }
        public string ExcelFilePath { get; set; }
        public string TextFilePath { get; set; }
        public List<StudentsDTO> listStudentDTO { get; set; }
        public List<UserDTO> listUserDTO { get; set; }
        #endregion

        #region C-tor
        public ExcelFileOfStudents(short seminarCode, string excelFilePath, string textFilePath)
        {
            SeminarCode = seminarCode;
            ExcelFilePath = excelFilePath;
            TextFilePath = textFilePath;
            listStudentDTO = new List<StudentsDTO>();
            listUserDTO = new List<UserDTO>();
        }
        #endregion

        //Functions
        #region FillingDataInTheTable
        public void FillingDataInTheTable()
        {
            //אכן קיים excel.txt בדיקה האם הקובץ
            if (File.Exists(TextFilePath))
            {
                var lines = File.ReadAllLines(TextFilePath, Encoding.Unicode);

                //המעבר על הקובץ מתחיל החל מהשורה השניה
                //מכיוון שבד"כ השורה הראשונה היא שורת כותרות
                int studentDTOIndex = 1;

                for (int i = studentDTOIndex; i < lines.Length; i++)
                {
                    var line = lines[i];
                    try
                    {
                        var lineParts = line.Split('\t');
                        #region Data from the Excel file - text file
                        var userFirstName = lineParts[0];
                        var userLastName = lineParts[1];
                        var userID = lineParts[2];
                        var userEnglishDateOfBirth = lineParts[3];
                        var userHebrewDateOfBirth = lineParts[4];
                        var userAddress = lineParts[5];
                        var userLocationCity = lineParts[6];
                        var userHomePhoneNumber = lineParts[7];
                        var studentFatherCellPhoneNumber = lineParts[8];
                        var studentMotherCellPhoneNumber = lineParts[9];
                        var userCellPhoneNumber = lineParts[10];
                        var studentGrade = lineParts[11];
                        var studentClassNumber = lineParts[12];
                        var studentFirstMajorName = lineParts[13];
                        var studentSecondMajorName = lineParts[14];
                        var userPassword = lineParts[15];
                        var studentYearOfStartingSchool = lineParts[16];
                        #endregion

                        //----------------------------------
                        #region New student member
                        StudentsDTO newStudentDTO = new StudentsDTO()
                        {
                            //StudentCode
                            StudentId = userID,
                            StudentFatherCellPhoneNumber = studentFatherCellPhoneNumber,
                            StudentMotherCellPhoneNumber = studentMotherCellPhoneNumber,
                            StudentGrade = studentGrade,
                            StudentClassNumber = Convert.ToInt16(studentClassNumber),
                            StudentFirstMajorCode = null,
                            StudentSecondMajorCode = null,
                            StudentLearnedFirstAid = false,
                            StudentIsStudyingTeaching = false,
                            StudentTeachingGuideCode = null,
                            StudentYearOfStartingSchool = Convert.ToDateTime(studentYearOfStartingSchool),
                            SeminarCode = SeminarCode,
                        };
                        #endregion

                        #region Added a new student to the list
                        listStudentDTO.Add(newStudentDTO);
                        #endregion

                        //----------------------------------
                        #region new user
                        UserDTO newUserDTO = new UserDTO()
                        {
                            UserId = userID,
                            UserPassword = PasswordLottery.PasswordLotteryFunction(),
                            UserFirstName = userFirstName,
                            UserLastName = userLastName,
                            UserHomePhoneNumber = userHomePhoneNumber,
                            UserCellPhoneNumber = userCellPhoneNumber,
                            UserHebrewDateOfBirth = userHebrewDateOfBirth,
                            UserEnglishDateOfBirth =new DateTime(),
                            //UserEnglishDateOfBirth = userEnglishDateOfBirth != "" ? Convert.ToDateTime(userEnglishDateOfBirth) : "",
                            UserAddress = userAddress,
                            UserLocationCity = userLocationCity
                        };
                        #endregion

                        #region Adding a new user to the list
                        listUserDTO.Add(newUserDTO);
                        #endregion

                    }
                    catch (Exception ex) { }
                    //מכיוון שאין לנו בו עוד צורך ושימוש excel.txt בסוף הריצה - נמחק את הקובץ 
                    finally
                    {
                        File.Delete(TextFilePath);
                    }
                }
            }
        }
        #endregion

    }
}
