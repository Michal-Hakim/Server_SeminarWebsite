using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IStaffDAL
    {
        //Get
        public List<StaffTbl> GetAllStaff();
        public StaffTbl GetStaffMemberByStaffCode(short staffCode);
        public StaffTbl? GetStaffMemberByStaffID(string staffID);
        public List<StaffTbl> GetAllStaffBySeminarCode(short seminarCode);

        //Put
        public List<StaffTbl> UpdateStaffMemberByStaffID(string staffID, StaffTbl staffTbl);
        //public List<StaffTbl> UpdateStaffMemberByStaffCode(short staffCode);
        //public List<StaffTbl> UpdateStaffMemberBySeminarCode(short seminarCode);

        //Post
        public List<StaffTbl> AddStaffMember(StaffTbl staffTbl);

        //Delete
        public List<StaffTbl> DeleteStaffMemberByStaffCode(short staffCode);
        public List<StaffTbl> DeleteStaffMembersBySeminarCode(short seminarCode);
    }
}
