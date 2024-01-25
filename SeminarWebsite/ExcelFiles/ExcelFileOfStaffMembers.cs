using DTO.Repository_DTO;
using System.Text;

namespace SeminarWebsite.ExcelFiles
{
    public class ExcelFileOfStaffMembers
    {
        #region Fields
        public short SeminarCode { get; set; }
        public string ExcelFilePath { get; set; }
        public string TextFilePath { get; set; }
        public List<StaffDTO> listStaffDTO { get; set; }
        public List<UserDTO> listUserDTO { get; set; }
        #endregion

        #region C-tor
        public ExcelFileOfStaffMembers(short seminarCode, string excelFilePath, string textFilePath)
        {
            SeminarCode = seminarCode;
            ExcelFilePath = excelFilePath;
            TextFilePath = textFilePath;
            listStaffDTO = new List<StaffDTO>();
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
                int staffDTOIndex = 1;

                for (int i = staffDTOIndex; i < lines.Length; i++)
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
                        var userCellPhoneNumber = lineParts[8];
                        var staffMemberPosition = lineParts[9];
                        var userPassword = lineParts[10];
                        var staffEmploymentStartDate = lineParts[11];
                        #endregion

                        //----------------------------------
                        #region New staff member
                        StaffDTO newStaffDTO = new StaffDTO()
                        {
                            //StaffCode = 0,
                            StaffId = userID,
                            StaffMemberPosition = staffMemberPosition,
                            StaffEmploymentStartDate = staffEmploymentStartDate != "" ? Convert.ToDateTime(staffEmploymentStartDate) : new DateTime(),
                            StaffStatus = true,
                            SeminarCode = SeminarCode
                        };
                        #endregion

                        #region Added a new staff member to the list
                        listStaffDTO.Add(newStaffDTO);
                        #endregion

                        //----------------------------------
                        #region new user
                        UserDTO newUserDTO = new UserDTO()
                        {
                            UserId = userID,
                            UserFirstName = userFirstName,
                            UserLastName = userLastName,
                            UserAddress = userAddress,
                            UserLocationCity = userLocationCity,
                            UserHomePhoneNumber = userHomePhoneNumber,
                            UserCellPhoneNumber = userCellPhoneNumber,
                            UserHebrewDateOfBirth = userHebrewDateOfBirth,
                            UserEnglishDateOfBirth = userEnglishDateOfBirth != "" ? Convert.ToDateTime(userEnglishDateOfBirth) : "",
                            UserPassword = PasswordLottery.PasswordLotteryFunction(),
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
