using DAL.Models;
using DTO.Repository_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStaffBLL
    {
        //Get
        public List<StaffDTO> GetAllStaff();
        public StaffDTO GetStaffMemberByStaffCode(short staffCode);
        public StaffDTO? GetStaffMemberByStaffID(string staffID);
        public List<StaffDTO> GetAllStaffBySeminarCode(short seminarCode);

        //Put
        public List<StaffDTO> UpdateStaffMemberByStaffID(string staffID, StaffDTO staffDTO);
        //public List<StaffDTO> UpdateStaffMemberByStaffCode(short staffCode);
        //public List<StaffDTO> UpdateStaffMemberBySeminarCode(short seminarCode);


        //Post
        public List<StaffDTO> AddStaffMember(StaffDTO staffDTO);

        //Delete
        //public List<StaffDTO> DeleteStaffMemberByStaffCode(short staffCode);
        //public List<StaffDTO> DeleteStaffMembersBySeminarCode(short seminarCode);
    }
}
