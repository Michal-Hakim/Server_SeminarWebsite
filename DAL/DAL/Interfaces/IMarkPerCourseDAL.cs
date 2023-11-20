using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IMarkPerCourseDAL
    {
        //Get
        public List<MarkPerCourseTbl> GetAllMarks();
        public List<MarkPerCourseTbl> GetAllMarksPerCourseByCourseCodeForTheMajor(short courseCodeForTheMajor);
        public List<MarkPerCourseTbl> GetAllMarksByStudentCode(short studentCode);

        //Put
        //public List<MarkPerCourseTbl> UpdateMarkByCourseCodeForTheMajorAndStudentCode(short codeCourseForTheMajor, short studentCode);
    }
}
