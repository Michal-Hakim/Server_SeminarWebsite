using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions
{
    public class SeminarActions : ISeminarDAL
    {
        readonly SeminarWebsiteContext _DB;

        #region C-tor
        public SeminarActions(SeminarWebsiteContext DB)
        {
            this._DB = DB;
        }
        #endregion

        //Get
        #region GetAllSeminars
        public List<SeminarTbl> GetAllSeminars()
        {
            return _DB.SeminarTbls.ToList();
        }
        #endregion

        #region GetSeminarBySeminarCode
        public SeminarTbl GetSeminarBySeminarCode(int code)
        {
            return _DB.SeminarTbls.FirstOrDefault(x => x.SeminarCode.Equals((short)code));
        }
        #endregion

        #region GetSeminarBySeminarEmailAddress
        public SeminarTbl GetSeminarBySeminarEmailAddress(string seminarEmailAddress)
        {
            return _DB.SeminarTbls.FirstOrDefault(x => x.SeminarEmailAddress.Equals(seminarEmailAddress));
        }
        #endregion

        #region GetSeminarBySeminarStatus
        public List<SeminarTbl> GetSeminarsBySeminarStatus(bool status)
        {
            return _DB.SeminarTbls.Where(x => x.SeminarStatus.Equals(status)).ToList();
        }
        #endregion

        //Put
        #region UpdateSeminar
        public List<SeminarTbl> UpdateSeminar(short code, SeminarTbl tbl)
        {
            SeminarTbl seminarToUpdate = _DB.SeminarTbls.FirstOrDefault(x => x.SeminarCode == code);
            if (seminarToUpdate != null)
            {
                seminarToUpdate.SeminarName = tbl.SeminarName;
                seminarToUpdate.SeminarAddress = tbl.SeminarAddress;
                seminarToUpdate.SeminarLocationCity = tbl.SeminarLocationCity;
                seminarToUpdate.SeminarPhoneNumber = tbl.SeminarPhoneNumber;
                seminarToUpdate.SeminarFaxNumber = tbl.SeminarFaxNumber;
                seminarToUpdate.SeminarEmailAddress = tbl.SeminarEmailAddress;
                //seminarToUpdate.SeminarManagerCode = tbl.SeminarManagerCode;
                //seminarToUpdate.SeminarManagerName = tbl.SeminarManagerName;
                seminarToUpdate.SeminarManagerPassword = tbl.SeminarManagerPassword;
                seminarToUpdate.SeminarStatus = tbl.SeminarStatus;
                _DB.SaveChanges();
            }
            return GetAllSeminars();
        }
        #endregion

        //Post
        #region AddSeminar
        public SeminarTbl AddSeminar(SeminarTbl seminarTbl)
        {
            _DB.SeminarTbls.Add(seminarTbl);
            _DB.SaveChanges();
            return _DB.SeminarTbls.OrderBy(x => x.SeminarCode).Last();
        }
        #endregion

        //Delete
        #region DeleteSeminar
        public List<SeminarTbl> DeleteSeminar(short code)
        {
            _DB.SeminarTbls.Remove(GetSeminarBySeminarCode(code));
            _DB.SaveChanges();
            return GetAllSeminars();
        }
        #endregion
    }
}
