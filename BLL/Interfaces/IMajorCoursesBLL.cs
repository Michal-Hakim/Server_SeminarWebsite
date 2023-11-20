using DAL.Models;
using DTO.Repository_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMajorCoursesBLL
    {
        //Get
        public MajorCoursesDTO GetMajorCourseByCourseCodeForTheMajor(short courseCodeForTheMajor);
        public List<MajorCoursesDTO> GetMajorCoursesTblByCourseTeacherCode(short courseTeacherCode);
        public List<MajorCoursesDTO> GetMajorAndCourseBySeminarCodeAndStaffCode(short seminarCode, short staffCode);
        public List<MajorCoursesDTO> GetMajorCoursesByMajorCodeAndByCourseGrade(short majorCode, string courseGrade);
        public List<MajorCoursesDTO> GetMajorAndCourseBySeminarCodeAndMajorCode(short seminarCode, short majorCode);
        public Dictionary<string, string> GetMajorCoursesInTheFormOfADictionaryByMajorCode_courseNameAndCourseTeacherName(short majorCode);
        public List<object> GetMajorCoursesInTheFormOfADictionaryByCourseTeacherCode_majorNameAndCourseName(short courseTeacherCode);
        public List<MajorCoursesDTO> GetMajorCoursesByMajorCode(short majorCode);

        //Post
        public MajorCoursesDTO AddAMajorCoursesByMajorCodeAndCourseGradeAndCourseNameAndCourseTeacherCode(short majorCode, string courseGrade, string courseName, short courseTeacherCode);
    }
}
