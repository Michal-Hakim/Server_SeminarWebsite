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
    public class StaffBLL : IStaffBLL
    {
        static readonly IMapper _Mapper;

        #region C-tor static
        static StaffBLL()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.AutoMapper>();
            });
            _Mapper = config.CreateMapper();
        }
        #endregion
        
        readonly IStaffDAL _staffDAL;

        #region C-tor public
        public StaffBLL(IStaffDAL staffDAL)
        {
            _staffDAL = staffDAL;
        }
        #endregion
        
        //Get
        #region GetAllStaff
        public List<StaffDTO> GetAllStaff()
        { 
            List<StaffDTO> staffDTO = new List<StaffDTO>(); 
            List<StaffTbl> staffTblToStaffDTO = _staffDAL.GetAllStaff();

            foreach (StaffTbl item in staffTblToStaffDTO)
                staffDTO.Add(_Mapper.Map<StaffTbl, StaffDTO>(item));

            return staffDTO;
        }
        #endregion

        #region GetAllStaffBySeminarCode
        public List<StaffDTO> GetAllStaffBySeminarCode(short seminarCode)
        {
            List<StaffDTO> staffDTO = new List<StaffDTO>();
            List<StaffTbl> staffTblToStaffDTO = _staffDAL.GetAllStaffBySeminarCode(seminarCode);

            foreach (StaffTbl item in staffTblToStaffDTO)
                staffDTO.Add(_Mapper.Map<StaffTbl, StaffDTO>(item));

            return staffDTO;
        }
        #endregion

        #region GetStaffMemberByStaffCode
        public StaffDTO GetStaffMemberByStaffCode(short staffCode)
        {
            return _Mapper.Map<StaffTbl, StaffDTO>(_staffDAL.GetStaffMemberByStaffCode(staffCode));
        }
        #endregion

        #region GetStaffMemberByStaffID
        public StaffDTO? GetStaffMemberByStaffID(string staffID)
        {
            return (_Mapper.Map<StaffTbl, StaffDTO?>(_staffDAL.GetStaffMemberByStaffID(staffID)));
        }
        #endregion

        //Put
        #region UpdateStaffMemberByStaffID
        public List<StaffDTO> UpdateStaffMemberByStaffID(string staffID, StaffDTO staffDTO)
        {
            _staffDAL.UpdateStaffMemberByStaffID(staffID, _Mapper.Map<StaffDTO, StaffTbl>(staffDTO));
            return GetAllStaff();
        }
        #endregion
        
        //Post
        #region AddStaffMember
        public List<StaffDTO> AddStaffMember(StaffDTO staffDTO)
        {
            _staffDAL.AddStaffMember(_Mapper.Map<StaffDTO, StaffTbl>(staffDTO));
            return GetAllStaff();
        }
        #endregion

        //Delete

    }
}
