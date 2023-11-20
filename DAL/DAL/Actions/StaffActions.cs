using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions
{
    public class StaffActions : IStaffDAL
    {
        readonly SeminarWebsiteContext _DB;

        #region C-tor
        public StaffActions(SeminarWebsiteContext DB)
        {
            this._DB = DB;
        }
        #endregion

        //Get
        #region GetAllStaff
        public List<StaffTbl> GetAllStaff()
        {
            return _DB.StaffTbls.ToList();
        }
        #endregion

        #region GetStaffMemberByStaffID
        public StaffTbl? GetStaffMemberByStaffID(string staffID)
        {
            return GetAllStaff().FirstOrDefault(x => x.StaffId.Equals(staffID));
        }
        #endregion

        #region GetAllStaffBySeminarCode
        public List<StaffTbl> GetAllStaffBySeminarCode(short seminarCode)
        {
            List<StaffTbl> listStaffTbl = new List<StaffTbl>();
            listStaffTbl = _DB.StaffTbls.Where(x => x.SeminarCode.Equals(seminarCode)).ToList();
            return listStaffTbl;
        }

        #endregion

        #region GetStaffMemberByStaffCode
        public StaffTbl GetStaffMemberByStaffCode(short staffCode)
        {
            StaffTbl staffTbl = _DB.StaffTbls.FirstOrDefault(x => x.StaffCode.Equals(staffCode));
            return staffTbl ?? null;
        }

        #endregion
        
        //Post
        #region AddStaffMember
        public List<StaffTbl> AddStaffMember(StaffTbl staffTbl)
        {
            _DB.StaffTbls.Add(staffTbl);
            _DB.SaveChanges();
            return GetAllStaff();
        }
        #endregion

        //Put
        #region UpdateStaffMemberByStaffID
        public List<StaffTbl> UpdateStaffMemberByStaffID(string staffID, StaffTbl staffTbl)
        {
            StaffTbl anExistingStaffMember = GetStaffMemberByStaffID(staffID);
            if (anExistingStaffMember == null)
            {
                anExistingStaffMember.StaffMemberPosition = staffTbl.StaffMemberPosition;
                anExistingStaffMember.StaffEmploymentStartDate = staffTbl.StaffEmploymentStartDate;
                anExistingStaffMember.StaffStatus = staffTbl.StaffStatus;
            }
            _DB.SaveChanges();

            return GetAllStaff();
        }
        #endregion

        //Delete
        #region DeleteStaffMemberByStaffCode
        public List<StaffTbl> DeleteStaffMemberByStaffCode(short staffCode)
        {
            StaffTbl staffTbl = _DB.StaffTbls.FirstOrDefault(x => x.StaffCode.Equals(staffCode));
            if (staffTbl != null)
            {
                _DB.StaffTbls.Remove(staffTbl);
                _DB.SaveChanges();
            }
            return GetAllStaff();
        }
        #endregion

        #region DeleteStaffMembersBySeminarCode
        public List<StaffTbl> DeleteStaffMembersBySeminarCode(short seminarCode)
        {
            List<StaffTbl> listStaffTbl = _DB.StaffTbls.Where(x => x.SeminarCode.Equals(seminarCode)).ToList();
            listStaffTbl.ForEach(x => _DB.StaffTbls.Remove(x));
            _DB.SaveChanges();
            return GetAllStaff();
        }
        #endregion
    }
}
