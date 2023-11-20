using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IStudentsDAL
    {
        //Get
        public StudentsTbl GetStudentByStudentCode(short studentCode);
        public StudentsTbl GetStudentByStudentID(string studentID);
        public List<StudentsTbl> GetAllStudents();
        public List<StudentsTbl> GetStudentsBySeminarCode(short seminarCode);
        public List<StudentsTbl> GetAllStudentsByStudentGradeAndSeminarCode(short studentGrade, short seminarCode);
        public List<StudentsTbl> GetAllStudentsByStudentGradeAndStudentClassNumberAndSeminarCode(short studentGrade, short studentClassNumber, short seminarCode);
        public List<StudentsTbl> GetAllStudentsByStudentMajorCodeAndStudentGradeAndSeminarCode(short studentMajorCode, short studentGrade, short seminarCode);
        public List<StudentsTbl> GetAllStudentsByStudentMajorCode(short studentMajorCode);
        public List<StudentsTbl> GetAllStudentsByStudentLearnedFirstAidAndSeminarCode(bool studentLearnedFirstAid, short seminarCode);
        public List<StudentsTbl> GetAllStudentsByStudentIsStudyingTeachingAndSeminarCode(bool studentIsStudyingTeaching, short seminarCode);
        public List<StudentsTbl> GetAllStudentsByStudentTeachingGuideCodeAndSeminarCode(short StudentTeachingGuideCode, short seminarCode);

        //Put
        public List<StudentsTbl> UpdateStudentByStudentID(string studentID, StudentsTbl studentsTbl);
        public StudentsTbl MatchingStudentToMajors(string studentID, short StudentFirstMajorCode, short StudentSecondMajorCode);
        //public List<StudentsTbl> UpdateStudentByStudentCode(short studentCode);

        //Post
        public List<StudentsTbl> AddStudent(StudentsTbl studentsTbl);

        //Delete
        public List<StudentsTbl> DeleteStudentByStudentCode(short studentCode);
        public List<StudentsTbl> DeleteStudentByStudentID(string studentID);
    }
}
