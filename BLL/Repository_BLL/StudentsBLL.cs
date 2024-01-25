using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO.Repository_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository_BLL
{
    public class StudentsBLL : IStudentsBLL
    {
        static readonly IMapper _Mapper;

        #region C-tor static
        static StudentsBLL()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.AutoMapper>();
            });
            _Mapper = config.CreateMapper();
        }
        #endregion

        readonly IStudentsDAL _studentsDAL;

        #region C-tor public
        public StudentsBLL(IStudentsDAL studentsDAL)
        {
            _studentsDAL = studentsDAL;
        }
        #endregion

        //Get
        #region GetAllStudents
        public List<StudentsDTO> GetAllStudents()
        {
            List<StudentsDTO> studentsDTO = new List<StudentsDTO>();
            List<StudentsTbl> studentsTblToStudentsDTO = _studentsDAL.GetAllStudents();

            foreach (StudentsTbl item in studentsTblToStudentsDTO)
            {
                studentsDTO.Add(_Mapper.Map<StudentsTbl, StudentsDTO>(item));
            }
            return studentsDTO;
        }
        #endregion

        #region GetAllStudentsByStudentMajorCode
        public List<StudentsDTO> GetAllStudentsByStudentMajorCode(short studentMajorCode)
        {
            List<StudentsTbl> studentsTbls = _studentsDAL.GetAllStudentsByStudentMajorCode(studentMajorCode);
            List<StudentsDTO> studentsDTOs = new List<StudentsDTO>();
            foreach (var student in studentsTbls)
            {
                studentsDTOs.Add(_Mapper.Map<StudentsTbl, StudentsDTO>(student));
            }
            return studentsDTOs;
        }
        #endregion

        #region GetStudentByStudentID
        public StudentsDTO GetStudentByStudentID(string studentID)
        {
            return _Mapper.Map<StudentsTbl, StudentsDTO>(_studentsDAL.GetStudentByStudentID(studentID));
        }
        #endregion

        #region GetStudentsBySeminarCode
        public List<StudentsDTO> GetStudentsBySeminarCode(short seminarCode)
        {
            List<StudentsDTO> studentsDTO = new List<StudentsDTO>();
            _studentsDAL.GetStudentsBySeminarCode(seminarCode).ForEach(x =>
            studentsDTO.Add(_Mapper.Map<StudentsTbl, StudentsDTO>(x)));
            return studentsDTO;
        }
        #endregion

        #region GetAllStudentsByStudentMajorCodeAndStudentGradeAndSeminarCode
        public List<StudentsDTO> GetAllStudentsByStudentMajorCodeAndStudentGradeAndSeminarCode(short studentMajorCode, short studentGrade, short seminarCode)
        {
            List<StudentsDTO> studentsDTO = new List<StudentsDTO>();
            _studentsDAL.GetAllStudentsByStudentMajorCodeAndStudentGradeAndSeminarCode(studentMajorCode, studentGrade, seminarCode).ForEach(
                x => studentsDTO.Add(_Mapper.Map<StudentsTbl, StudentsDTO>(x)));
            return studentsDTO;
        }
        #endregion

        #region GetAllStudentsByStudentGradeAndSeminarCode
        public List<StudentsDTO> GetAllStudentsByStudentGradeAndSeminarCode(string studentGrade, short seminarCode)
        {
            List<StudentsTbl> studentsTbl = _studentsDAL.GetAllStudentsByStudentGradeAndSeminarCode(studentGrade, seminarCode);
            List<StudentsDTO> studentsDTO = new List<StudentsDTO>();
            studentsTbl.ForEach(x => studentsDTO.Add(_Mapper.Map<StudentsTbl, StudentsDTO>(x)));
            return studentsDTO;
        }
        #endregion

        #region GetAllStudentsByStudentGradeAndStudentClassNumberAndSeminarCode
        public List<StudentsDTO> GetAllStudentsByStudentGradeAndStudentClassNumberAndSeminarCode(string studentGrade, short studentClassNumber, short seminarCode)
        {
            List<StudentsTbl> studentsTbl = _studentsDAL.GetAllStudentsByStudentGradeAndStudentClassNumberAndSeminarCode(studentGrade, studentClassNumber, seminarCode);
            List<StudentsDTO> studentsDTO = new List<StudentsDTO>();
            studentsTbl.ForEach(x => studentsDTO.Add(_Mapper.Map<StudentsTbl, StudentsDTO>(x)));
            return studentsDTO;
        }
        #endregion

        //Put
        #region UpdateStudentByStudentID
        public List<StudentsDTO> UpdateStudentByStudentID(string studentID, StudentsDTO studentDTO)
        {
            _studentsDAL.UpdateStudentByStudentID(studentID, _Mapper.Map<StudentsDTO, StudentsTbl>(studentDTO));
            return GetAllStudents();
        }
        #endregion

        #region MatchingStudentToMajors
        public StudentsDTO MatchingStudentToMajors(string studentID, short StudentFirstMajorCode, short StudentSecondMajorCode)
        {
            return _Mapper.Map<StudentsTbl, StudentsDTO>(_studentsDAL.MatchingStudentToMajors(studentID, StudentFirstMajorCode, StudentSecondMajorCode));
        }

        #endregion

        #region UpStudentGradeBySeminarCode
        public List<StudentsDTO> UpStudentGradeBySeminarCode(short seminarCode)
        {
            List<StudentsTbl> studentsTbls = _studentsDAL.UpStudentGradeBySeminarCode(seminarCode);
            List<StudentsDTO> studentsDTOs = studentsTbls.Select(x => _Mapper.Map<StudentsTbl, StudentsDTO>(x)).ToList();
            return studentsDTOs;
        }

        #endregion

        //Post
        #region AddStudent
        public List<StudentsDTO> AddStudent(StudentsDTO studentsDTO)
        {
            _studentsDAL.AddStudent(_Mapper.Map<StudentsDTO, StudentsTbl>(studentsDTO));
            return GetAllStudents();
        }
        #endregion

        //Delete

    }
}
