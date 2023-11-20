using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IMajorCoursesDAL
    {
        //Get
        public MajorCoursesTbl GetMajorCourseByMajorCode(short majorCode);
        public MajorCoursesTbl GetMajorCourseByCourseCodeForTheMajor(short CourseCodeForTheMajor);
        public MajorCoursesTbl GetMajorCoursesByMajorCodeAndCourseCode(short majorCode, short courseCode);
        public List<MajorCoursesTbl> GetAllMajorCourses();
        public List<MajorCoursesTbl> GetMajorCoursesTblByCourseTeacherCode(short courseTeacherCode);
        public List<MajorCoursesTbl> GetMajorAndCourseBySeminarCodeAndStaffCode(short seminarCode, short staffCode);
        public List<MajorCoursesTbl> GetMajorCoursesByMajorCode(short majorCode);
        public List<MajorCoursesTbl> GetMajorCoursesByMajorCodeAndByCourseGrade(short majorCode, string courseGrade);
        public List<MajorCoursesTbl> GetMajorAndCourseBySeminarCodeAndMajorCode(short seminarCode, short majorCode);

        //Post
        public MajorCoursesTbl AddAMajorCoursesByMajorCodeAndCourseGradeAndCourseNameAndCourseTeacherCode(short majorCode, string courseGrade, string courseName, short courseTeacherCode);

    }
}
