using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Office.Interop.Excel;

using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace SeminarWebsite.ExcelFiles
{
    static class FunctionsOnExcelFiles
    {
        #region UploadAnExcelFileToTheWwwrootFolder
        public static void UploadAnExcelFileToTheWwwrootFolder(this IFormFile fileExcel, string pathDirectory)
        {
            #region Save the uploaded Excel file.
            string fileName = Path.GetFileName(fileExcel.FileName);
            string filePath = Path.Combine(pathDirectory, fileName);
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                fileExcel.CopyTo(stream);
            }
            #endregion
        }
        #endregion

        #region ConvertAnExcelFileToATextFile
        public static void ConvertAnExcelFileToATextFile(this string pathToExcelFile, string pathToPlaceATextFile)
        {
            var app = new Application();

            try
            {
                app.DisplayAlerts = false;
                app.Visible = false;

                var book = app.Workbooks.Open(pathToExcelFile);

                book.SaveAs(Filename: pathToPlaceATextFile, FileFormat: XlFileFormat.xlUnicodeText,
                    AccessMode: XlSaveAsAccessMode.xlNoChange,
                    ConflictResolution: XlSaveConflictResolution.xlLocalSessionChanges);
                book.Close();
            }
            finally
            {
                app.Quit();
            }
        }
        #endregion

        #region DeletingAnExcelFile
        public static void DeletingAnExcelFile(this string excelFilePath)
        {
            if (File.Exists(excelFilePath))
                File.Delete(excelFilePath);
        }
        #endregion

        #region DeletingATextFile
        public static void DeletingATextFile(this string textFilePath)
        {
            if (File.Exists(textFilePath))
                File.Delete(textFilePath);
        }
        #endregion
    }
}
