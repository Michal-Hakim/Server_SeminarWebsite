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
    public class SeminarBLL : ISeminarBLL
    {
        static readonly IMapper _Mapper;

        #region C-tor static
        static SeminarBLL()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.AutoMapper>();
            });
            _Mapper = config.CreateMapper();
        }
        #endregion

        readonly ISeminarDAL _seminarDAL;

        #region C-tor public
        public SeminarBLL(ISeminarDAL seminarDAL)
        {
            _seminarDAL = seminarDAL;
        }
        #endregion

        //Get
        #region GetAllSeminars
        public List<SeminarDTO> GetAllSeminars()
        {
            List<SeminarDTO> seminarDTO = new List<SeminarDTO>();
            List<SeminarTbl> seminarTblToSeminarDTO = _seminarDAL.GetAllSeminars();

            foreach (SeminarTbl item in seminarTblToSeminarDTO)
                seminarDTO.Add(_Mapper.Map<SeminarTbl, SeminarDTO>(item));

            return seminarDTO;
        }
        #endregion

        #region GetSeminarBySeminarCode
        public SeminarDTO GetSeminarBySeminarCode(int code)
        {
            return _Mapper.Map<SeminarTbl, SeminarDTO>(_seminarDAL.GetSeminarBySeminarCode((short)code));
        }
        #endregion

        #region GetSeminarBySeminarEmailAddress
        public SeminarDTO GetSeminarBySeminarEmailAddress(string seminarEmailAddress)
        {
            return _Mapper.Map<SeminarTbl, SeminarDTO>(_seminarDAL.GetSeminarBySeminarEmailAddress(seminarEmailAddress));
        }
        #endregion

        //Put
        #region UpdateSeminar
        public List<SeminarDTO> UpdateSeminar(short code, SeminarDTO seminarDTO)
        {
            _seminarDAL.UpdateSeminar(code, _Mapper.Map<SeminarDTO, SeminarTbl>(seminarDTO));
            return GetAllSeminars();
        }
        #endregion

        //Post
        #region AddSeminar
        public SeminarDTO AddSeminar(SeminarDTO seminarDTO)
        {
            return _Mapper.Map<SeminarTbl, SeminarDTO>(_seminarDAL.AddSeminar(_Mapper.Map<SeminarDTO, SeminarTbl>(seminarDTO)));
        }
        #endregion

        //Delete
        #region DeleteSeminar
        public List<SeminarDTO> DeleteSeminar(short code)
        {
            _seminarDAL.DeleteSeminar(code);
            return GetAllSeminars();
        }
        #endregion
    }
}
