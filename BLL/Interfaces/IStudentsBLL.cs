using DAL.Models;
using DTO.Repository_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStudentsBLL
    {
        //Get
        public StudentsDTO GetStudentByStudentID(string studentID);
        public List<StudentsDTO> GetAllStudents();
        public List<StudentsDTO> GetStudentsBySeminarCode(short seminarCode);
        public List<StudentsDTO> GetAllStudentsByStudentMajorCodeAndStudentGradeAndSeminarCode(short studentMajorCode, short studentGrade, short seminarCode);
        public List<StudentsDTO> GetAllStudentsByStudentMajorCode(short studentMajorCode);
        //public StudentsDTO GetStudentByStudentCode(short studentCode);
        //public List<StudentsDTO> GetAllStudentsByStudentLearnedFirstAidAndSeminarCode(bool studentLearnedFirstAid, short seminarCode);
        //public List<StudentsDTO> GetAllStudentsByStudentIsStudyingTeachingAndSeminarCode(bool studentIsStudyingTeaching, short seminarCode);
        //public List<StudentsDTO> GetAllStudentsByStudentTeachingGuideCodeAndSeminarCode(short StudentTeachingGuideCode, short seminarCode);
        //public List<StudentsDTO> GetAllStudentsByStudentGradeAndSeminarCode(short studentGrade, short seminarCode);
        //public List<StudentsDTO> GetAllStudentsByStudentGradeAndStudentClassNumberAndSeminarCode(short studentGrade, short studentClassNumber, short seminarCode);

        //Put
        public List<StudentsDTO> UpdateStudentByStudentID(string studentID, StudentsDTO studentDTO);
        public StudentsDTO MatchingStudentToMajors(string studentID, short StudentFirstMajorCode, short StudentSecondMajorCode);
        //public List<StudentsDTO> UpdateStudentByStudentCode(short studentCode);

        //Post
        public List<StudentsDTO> AddStudent(StudentsDTO studentsDTO);

        //Delete
        //public List<StudentsDTO> DeleteStudentByStudentCode(short studentCode);
        //public List<StudentsDTO> DeleteStudentByStudentID(string studentID);
    }
}
