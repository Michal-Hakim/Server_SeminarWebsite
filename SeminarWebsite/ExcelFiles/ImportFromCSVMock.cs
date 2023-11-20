using BLL.Repository_BLL;
using DAL;
using DTO.Repository_DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;

namespace SeminarWebsite.ExcelFiles
{
    public static class ImportFromCSVMockClass
    {
        //excel.xlsx יצירת משתנה שיכיל את קובץ ה
        //שזהו בעצם אותו קובץ רק בקידוד שונה excel.txt כקובץ בסיומת  
        public const string TempTxtPath = "C:\\FinalProject\\temp.txt";

        //excel.txt לקובץ excel.xlsx פונקציה שממירה את קובץ ה 
        public static void ConvertXlsxToTxt(string fromPath, string toPath)
        {
            var app = new Microsoft.Office.Interop.Excel.Application();

            try
            {
                app.DisplayAlerts = false;
                app.Visible = false;

                var book = app.Workbooks.Open(fromPath);
                //אם הוא קיים excel.txt שליחה לפונקציה המוחקת את הקובץ
                DeleteTempTxtFileIsExists();
                book.SaveAs(Filename: toPath, FileFormat: Microsoft.Office.Interop.Excel.XlFileFormat.xlUnicodeText,
                    AccessMode: Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                    ConflictResolution: Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges);
                book.Close();
            }
            finally
            {
                app.Quit();
            }
        }

        //אם הוא קיים excel.txt פונקציה המוחקת את הקובץ
        private static void DeleteTempTxtFileIsExists()
        {
            if (File.Exists(TempTxtPath))
                File.Delete(TempTxtPath);
        }

        //excel.xlsx פונקציה שמקבלת קובץ
        //excel.txt לקובץ excel.xlsx הפונקציה ממירה את הקובץ 
        //DB אח"כ היא עוברת על כל שורה בקובץ ומכניסה אותה ל
        public static List<SeminarDTO> ImportFromCSV(string xlsxPath)
        {
            //excel.txt לקובץ excel.xlsx שליחה לפונקציה שממירה את קובץ ה 
            ConvertXlsxToTxt(xlsxPath, TempTxtPath);
            //יצירת רשימה מסוג טבלה כלשהיא שאליה נכניס את הנתונים
            //DB עבור כל שורה - נקבץ אותה כאובייקט מסוג הטבלה הרצויה ואח"כ נכניס אותה ל 
            List<SeminarDTO> seminarDTO = new List<SeminarDTO>();

            //אכן קיים excel.txt בדיקה האם הקובץ
            if (File.Exists(TempTxtPath))
            {
                var lines = File.ReadAllLines(TempTxtPath, Encoding.Unicode);

                //המעבר על הקובץ מתחיל החל מהשורה השניה
                //מכיוון שבד"כ השורה הראשונה היא שורת כותרות
                int seminarDTOIndex = 1;

                for (int i = seminarDTOIndex; i < lines.Length; i++)
                {
                    var line = lines[i];
                    //נסיון לגשת לנתונים מתוך הקובץ
                    try
                    {
                        var lineParts = line.Split('\t');
                        var seminarName = lineParts[0];
                        //var name = lineParts[1].Replace("\"\"", "\"").Trim('\"').TrimEnd('\"');
                        //var type = lineParts[2];
                        //var isImport = lineParts[3];

                        //לטבלה הרצויה DB יצירת האיבר שאותו אנו נכניס ל
                        var device = new SeminarDTO()
                        {
                            SeminarName = seminarName,
                            //SeminarManagerCode = 0,
                            SeminarStatus = false,
                            SeminarManagerPassword = "ff"
                        };
                        //הוספה לרשימה מסוג הטבלה הרצויה
                        seminarDTO.Add(device);

                    }
                    catch (Exception)
                    {
                    }
                    //מכיוון שאין לנו בו עוד צורך ושימוש excel.txt בסוף הריצה - נמחק את הקובץ 
                    finally
                    {
                        File.Delete(TempTxtPath);
                    }
                }
            }
            return seminarDTO;
        }
    }
}
