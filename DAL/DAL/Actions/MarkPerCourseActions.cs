using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions
{
    public class MarkPerCourseActions : IMarkPerCourseDAL
    {
        readonly SeminarWebsiteContext _DB;

        #region C-tor
        public MarkPerCourseActions(SeminarWebsiteContext DB)
        {
            this._DB = DB;
        }
        #endregion

        //Get
        #region GetAllMarks
        public List<MarkPerCourseTbl> GetAllMarks()
        {
            return _DB.MarkPerCourseTbls.ToList();
        }
        #endregion

        #region GetAllMarksByStudentCode
        public List<MarkPerCourseTbl> GetAllMarksByStudentCode(short studentCode)
        {
            return _DB.MarkPerCourseTbls.Where(x => x.StudentCode.Equals(studentCode)).ToList();
        }
        #endregion

        #region GetAllMarksPerCourseByCourseCodeForTheMajor
        public List<MarkPerCourseTbl> GetAllMarksPerCourseByCourseCodeForTheMajor(short courseCodeForTheMajor)
        {
            return _DB.MarkPerCourseTbls.Where(x => x.CourseCodeForTheMajor.Equals(courseCodeForTheMajor)).ToList();
        }
        #endregion

        //Put

        //Post

        //Delete




    }
}
