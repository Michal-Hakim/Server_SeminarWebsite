using DAL.Interfaces;
using DTO.Repository_DTO;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace SeminarWebsite.ExcelFiles
{
    public class UploadingDataFromAnExcelFile_StaffTbl
    {
        //        //excel.xlsx יצירת משתנה שיכיל את קובץ ה
        //        //שזהו בעצם אותו קובץ רק בקידוד שונה excel.txt כקובץ בסיומת 
        public string TempTxtPath { get; set; }
        public static List<StaffDTO> listStaffDTO;
        public static List<UserDTO> listUserDTO;
        //C-tor
        #region C-tor
        public UploadingDataFromAnExcelFile_StaffTbl(string tempTxtPath)
        {
            TempTxtPath = tempTxtPath;
            listStaffDTO = new List<StaffDTO>();
            listUserDTO = new List<UserDTO>();
        }
        #endregion

        #region fill data from text file - to the table staff and user
        public void fillData()
        {
            //אכן קיים excel.txt בדיקה האם הקובץ
            if (File.Exists(TempTxtPath))
            {
                var lines = File.ReadAllLines(TempTxtPath, Encoding.Unicode);

                //המעבר על הקובץ מתחיל החל מהשורה השניה
                //מכיוון שבד"כ השורה הראשונה היא שורת כותרות
                int staffDTOIndex = 1;

                for (int i = staffDTOIndex; i < lines.Length; i++)
                {
                    var line = lines[i];
                    //נסיון לגשת לנתונים מתוך הקובץ
                    try
                    {
                        var lineParts = line.Split('\t');

                        var userID = lineParts[0];
                        var userFirstName = lineParts[1];
                        var userLastName = lineParts[2];
                        var userHomePhoneNumber = lineParts[3];
                        var userCellPhoneNumber = lineParts[4];
                        var userAddress = lineParts[5];
                        var userLocationCity = lineParts[6];
                        var staffMemberPosition = lineParts[7];
                        var staffEmploymentStartDate = lineParts[8];

                        //var seminarName = lineParts[0];
                        //var name = lineParts[1].Replace("\"\"", "\"").Trim('\"').TrimEnd('\"');
                        //var type = lineParts[2];
                        //var isImport = lineParts[3];

                        //לטבלה הרצויה DB יצירת האיבר שאותו אנו נכניס ל
                        StaffDTO newStaffDTO = new StaffDTO()
                        {
                            //StaffCode = short.Parse(),
                            StaffId = userID,
                            StaffMemberPosition = staffMemberPosition,
                            StaffEmploymentStartDate = staffEmploymentStartDate != "" ? Convert.ToDateTime(staffEmploymentStartDate) : new DateTime(),
                            StaffStatus = true //,
                                               //SeminarCode
                        };

                        //הוספה לרשימה מסוג הטבלה הרצויה
                        listStaffDTO.Add(newStaffDTO);

                        UserDTO newUserDTO = new UserDTO()
                        {
                            UserId = userID,
                            UserPassword = PasswordLottery.PasswordLotteryFunction(),
                            UserFirstName = userFirstName,
                            UserLastName = userLastName,
                            UserHomePhoneNumber = userHomePhoneNumber,
                            UserCellPhoneNumber = userCellPhoneNumber,
                            UserHebrewDateOfBirth = null,
                            UserEnglishDateOfBirth = null,
                            UserAddress = userAddress,
                            UserLocationCity = userLocationCity
                        };

                        //הוספה לרשימה מסוג הטבלה הרצויה
                        listUserDTO.Add(newUserDTO);
                    }
                    catch (Exception ex)
                    {
                    }
                    //מכיוון שאין לנו בו עוד צורך ושימוש excel.txt בסוף הריצה - נמחק את הקובץ 
                    finally
                    {
                        //File.Delete(textFile);
                    }
                }
            }
        }
        #endregion
    }
}
