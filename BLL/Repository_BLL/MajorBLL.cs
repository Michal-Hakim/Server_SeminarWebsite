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
    public class MajorBLL : IMajorBLL
    {
        static readonly IMapper _Mapper;

        #region C-tor static
        static MajorBLL()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.AutoMapper>();
            });
            _Mapper = config.CreateMapper();
        }
        #endregion

        readonly IMajorDAL _majorDAL;
        readonly IMajorCoursesBLL _majorCourseBLL;

        #region C-tor public
        public MajorBLL(IMajorDAL majorDAL, IMajorCoursesBLL majorCourseBLL)
        {
            _majorDAL = majorDAL;
            _majorCourseBLL = majorCourseBLL;
        }
        #endregion

        //Get

        #region GetAllMajors
        public List<MajorDTO> GetAllMajors()
        {
            List<MajorTbl> majorsTbl = _majorDAL.GetAllMajors();
            List<MajorDTO> majorDTOs = new List<MajorDTO>();
            majorsTbl.ForEach(x => majorDTOs.Add(_Mapper.Map<MajorTbl, MajorDTO>(x)));
            return majorDTOs;
        }
        #endregion

        #region GetMajorByMajorCode
        public MajorDTO GetMajorByMajorCode(short majorCode)
        {
            return _Mapper.Map<MajorTbl, MajorDTO>(_majorDAL.GetMajorByMajorCode(majorCode));
        }
        #endregion

        #region GetMajorsBySeminarAndTeacherCode
        public List<MajorDTO> GetMajorsBySeminarAndTeacherCode(short seminarCode, short staffCode)
        {
            List<MajorDTO> majorDTO = new List<MajorDTO>();
            List<MajorCoursesDTO> majorCoursesDTO = _majorCourseBLL.GetMajorAndCourseBySeminarCodeAndStaffCode(seminarCode, staffCode);
            foreach (MajorCoursesDTO item in majorCoursesDTO)
            {
                MajorDTO m = GetMajorByMajorCode(item.MajorCode);
                if (m != null && majorDTO.FirstOrDefault(x => x.MajorCode.Equals(item.MajorCode)) == null)
                    majorDTO.Add(m);
            }
            return majorDTO;
        }
        #endregion

        #region GetMajorBySeminarCode
        public List<MajorDTO> GetMajorBySeminarCode(short seminarCode)
        {
            List<MajorTbl> majorsTbl = _majorDAL.GetMajorBySeminarCode(seminarCode);
            List<MajorDTO> majorsDTO = new List<MajorDTO>();
            majorsTbl.ForEach(x => majorsDTO.Add(_Mapper.Map<MajorTbl, MajorDTO>(x)));
            return majorsDTO;
        }
        #endregion

        #region GetMajorBySeminarCodeAndMajorCode
        public MajorDTO GetMajorBySeminarCodeAndMajorCode(short seminarCode, short majorCode)
        {
            return _Mapper.Map<MajorTbl, MajorDTO>(_majorDAL.GetMajorBySeminarCodeAndMajorCode(seminarCode, majorCode));
        }
        #endregion

        #region GetMajorByMajorName
        public MajorDTO GetMajorByMajorName(string majorName)
        {
            return _Mapper.Map<MajorTbl, MajorDTO>(_majorDAL.GetMajorByMajorName(majorName));
        }
        #endregion

        //Put

        //Post
        #region AddMajor
        public MajorDTO AddMajor(MajorDTO majorDTO)
        {
            return _Mapper.Map<MajorTbl, MajorDTO>(_majorDAL.AddMajor(_Mapper.Map<MajorDTO, MajorTbl>(majorDTO)));
        }
        #endregion

        //Delete

    }
}
