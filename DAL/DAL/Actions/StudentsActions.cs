using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions
{
    public class StudentsActions : IStudentsDAL
    {
        readonly SeminarWebsiteContext _DB;

        #region C-tor
        public StudentsActions(SeminarWebsiteContext DB)
        {
            this._DB = DB;
        }
        #endregion
        
        //Get
        #region GetStudentByStudentCode
        public StudentsTbl GetStudentByStudentCode(short studentCode)
        {
            return _DB.StudentsTbls.FirstOrDefault(x => x.StudentCode.Equals(studentCode));
        }
        #endregion

        #region GetStudentByStudentID
        public StudentsTbl GetStudentByStudentID(string studentID)
        {
            return _DB.StudentsTbls.FirstOrDefault(x => x.StudentId.Equals(studentID)); ;
        }
        #endregion

        #region GetAllStudents
        public List<StudentsTbl> GetAllStudents()
        {
            return _DB.StudentsTbls.ToList();
        }
        #endregion

        #region GetStudentsBySeminarCode
        public List<StudentsTbl> GetStudentsBySeminarCode(short seminarCode)
        {
            List<StudentsTbl> listStudentsTbl = new List<StudentsTbl>();
            List<string> grades = new List<string> { "A", "B", "C" };
            listStudentsTbl = _DB.StudentsTbls.Where(x => x.SeminarCode.Equals(seminarCode) && grades.Contains(x.StudentGrade)).ToList();
            return listStudentsTbl;
        }
        #endregion

        #region GetAllStudentsByStudentGradeAndSeminarCode
        public List<StudentsTbl> GetAllStudentsByStudentGradeAndSeminarCode(short studentGrade, short seminarCode)
        {
            return GetStudentsBySeminarCode(seminarCode).Where(x => x.StudentGrade.Equals(studentGrade)).ToList();
        }
        #endregion

        #region GetAllStudentsByStudentGradeAndStudentClassNumberAndSeminarCode
        public List<StudentsTbl> GetAllStudentsByStudentGradeAndStudentClassNumberAndSeminarCode(short studentGrade, short studentClassNumber, short seminarCode)
        {
            return GetAllStudentsByStudentGradeAndSeminarCode(studentGrade, seminarCode).Where(x => x.StudentClassNumber.Equals(studentClassNumber)).ToList();
        }
        #endregion

        #region GetAllStudentsByStudentMajorCodeAndStudentGradeAndSeminarCode
        public List<StudentsTbl> GetAllStudentsByStudentMajorCodeAndStudentGradeAndSeminarCode(short studentMajorCode, short studentGrade, short seminarCode)
        {
            return GetAllStudentsByStudentMajorCode(studentMajorCode).Where(x => x.StudentGrade.Equals(studentGrade) && x.SeminarCode.Equals(seminarCode)).ToList();
        }
        #endregion

        #region GetAllStudentsByStudentMajorCode
        public List<StudentsTbl> GetAllStudentsByStudentMajorCode(short studentMajorCode)
        {
            return _DB.StudentsTbls.Where(x => x.StudentFirstMajorCode.Equals(studentMajorCode) || x.StudentSecondMajorCode.Equals(studentMajorCode)).ToList();
        }
        #endregion

        #region GetAllStudentsByStudentLearnedFirstAidAndSeminarCode
        public List<StudentsTbl> GetAllStudentsByStudentLearnedFirstAidAndSeminarCode(bool studentLearnedFirstAid, short seminarCode)
        {
            return GetStudentsBySeminarCode(seminarCode).Where(x => x.StudentLearnedFirstAid.Equals(studentLearnedFirstAid)).ToList();
        }
        #endregion

        #region GetAllStudentsByStudentIsStudyingTeachingAndSeminarCode
        public List<StudentsTbl> GetAllStudentsByStudentIsStudyingTeachingAndSeminarCode(bool studentIsStudyingTeaching, short seminarCode)
        {
            return GetStudentsBySeminarCode(seminarCode).Where(x => x.StudentIsStudyingTeaching.Equals(studentIsStudyingTeaching)).ToList();
        }
        #endregion

        #region GetAllStudentsByStudentTeachingGuideCodeAndSeminarCode
        public List<StudentsTbl> GetAllStudentsByStudentTeachingGuideCodeAndSeminarCode(short StudentTeachingGuideCode, short seminarCode)
        {
            return GetStudentsBySeminarCode(seminarCode).Where(x => x.StudentTeachingGuideCode.Equals(StudentTeachingGuideCode)).ToList();
        }
        #endregion

        //Post
        #region AddStudent
        public List<StudentsTbl> AddStudent(StudentsTbl studentsTbl)
        {
            _DB.StudentsTbls.Add(studentsTbl);
            _DB.SaveChanges();
            return GetAllStudents();
        }
        #endregion
        
        //Put
        #region UpdateStudentByStudentID
        public List<StudentsTbl> UpdateStudentByStudentID(string studentID, StudentsTbl studentsTbl)
        {
            StudentsTbl anExistingStudent = GetStudentByStudentID(studentID);
            if(anExistingStudent != null)
            {
                //anExistingStudent.StudentCode
                //anExistingStudent.StudentId
                anExistingStudent.StudentFatherCellPhoneNumber = studentsTbl.StudentFatherCellPhoneNumber;
                anExistingStudent.StudentMotherCellPhoneNumber = studentsTbl.StudentMotherCellPhoneNumber;
                //anExistingStudent.SeminarCode
                anExistingStudent.StudentYearOfStartingSchool = studentsTbl.StudentYearOfStartingSchool;
                anExistingStudent.StudentGrade = studentsTbl.StudentGrade;
                anExistingStudent.StudentClassNumber = studentsTbl.StudentClassNumber;
                anExistingStudent.StudentFirstMajorCode = studentsTbl.StudentFirstMajorCode;
                anExistingStudent.StudentSecondMajorCode = studentsTbl.StudentSecondMajorCode;
                anExistingStudent.StudentLearnedFirstAid = studentsTbl.StudentLearnedFirstAid;
                anExistingStudent.StudentIsStudyingTeaching = studentsTbl.StudentIsStudyingTeaching;
                anExistingStudent.StudentTeachingGuideCode = studentsTbl.StudentTeachingGuideCode;
            };
            _DB.SaveChanges();

            return GetAllStudents();
        }
        #endregion

        #region MatchingStudentToMajors
        public StudentsTbl MatchingStudentToMajors(string studentID, short StudentFirstMajorCode, short StudentSecondMajorCode)
        {
            StudentsTbl student = GetStudentByStudentID(studentID);
            student.StudentFirstMajorCode = StudentFirstMajorCode==0?null:StudentFirstMajorCode;
            student.StudentSecondMajorCode = StudentSecondMajorCode==0?null:StudentSecondMajorCode;
            _DB.SaveChanges();
            return student;
        }
        #endregion

        //Delete
        #region DeleteStudentByStudentCode
        public List<StudentsTbl> DeleteStudentByStudentCode(short studentCode)
        {
            _DB.StudentsTbls.Remove(GetStudentByStudentCode(studentCode));
            _DB.SaveChanges();
            return GetAllStudents();
        }
        #endregion

        #region DeleteStudentByStudentID
        public List<StudentsTbl> DeleteStudentByStudentID(string studentID)
        {
            _DB.StudentsTbls.Remove(GetStudentByStudentID(studentID));
            _DB.SaveChanges();
            return GetAllStudents();
        }
        #endregion
    }
}
