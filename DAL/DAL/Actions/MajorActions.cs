using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions
{
    public class MajorActions : IMajorDAL
    {
        readonly SeminarWebsiteContext _DB;

        #region C-tor
        public MajorActions(SeminarWebsiteContext DB)
        {
            this._DB = DB;
        }
        #endregion

        //Get
        #region GetAllMajors
        public List<MajorTbl> GetAllMajors()
        {
            return _DB.MajorTbls.ToList();
        }
        #endregion

        #region GetMajorByMajorCode
        public MajorTbl GetMajorByMajorCode(short majorCode)
        {
            return _DB.MajorTbls.FirstOrDefault(x => x.MajorCode.Equals(majorCode));
        }
        #endregion

        #region GetMajorBySeminarCode
        public List<MajorTbl> GetMajorBySeminarCode(short seminarCode)
        {
            return _DB.MajorTbls.Where(x => x.SeminarCode.Equals(seminarCode)).ToList();
        }
        #endregion

        #region GetMajorBySeminarCodeAndMajorCodeCoordinator
        public List<MajorTbl> GetMajorBySeminarCodeAndMajorCodeCoordinator(short seminarCode, short majorCodeCoordinator)
        {
            return GetMajorBySeminarCode(seminarCode).Where(x => x.MajorCodeCoordinator.Equals(majorCodeCoordinator)).ToList();
        }
        #endregion

        #region GetMajorBySeminarCodeAndMajorName
        public List<MajorTbl> GetMajorBySeminarCodeAndMajorName(short seminarCode, string majorName)
        {
            return GetMajorBySeminarCode(seminarCode).Where(x => x.MajorName.Equals(majorName)).ToList();
        }
        #endregion

        #region GetMajorBySeminarCodeAndMajorCode
        public MajorTbl GetMajorBySeminarCodeAndMajorCode(short seminarCode, short majorCode)
        {
            return GetMajorBySeminarCode(seminarCode).FirstOrDefault(x => x.MajorCode.Equals(majorCode));
        }
        #endregion

        #region GetMajorByMajorName
        public MajorTbl GetMajorByMajorName(string majorName)
        {
            return _DB.MajorTbls.FirstOrDefault(x => x.MajorName.Equals(majorName));
        }
        #endregion

        //Put

        //Post
        #region AddMajor
        public MajorTbl AddMajor(MajorTbl majorTbl)
        {
            _DB.MajorTbls.Add(majorTbl);
            _DB.SaveChanges();
            return _DB.MajorTbls.OrderBy(x => x.MajorCode).Last();
        }
        #endregion

        //Delete
        #region DeleteMajorByMajorCode
        public List<MajorTbl> DeleteMajorByMajorCode(short majorCode)
        {
            _DB.MajorTbls.Remove(GetMajorByMajorCode(majorCode));
            _DB.SaveChanges();
            return GetAllMajors();
        }
        #endregion
    }
}
