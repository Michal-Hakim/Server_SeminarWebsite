using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface ISeminarDAL
    {
        //Get
        public List<SeminarTbl> GetAllSeminars();
        public SeminarTbl GetSeminarBySeminarCode(int code);
        public SeminarTbl GetSeminarBySeminarEmailAddress(string seminarEmailAddress);
        public List<SeminarTbl> GetSeminarsBySeminarStatus(bool status);

        //Put
        public List<SeminarTbl> UpdateSeminar(short code, SeminarTbl tbl);

        //Post
        public SeminarTbl AddSeminar(SeminarTbl seminarTbl);

        //Delete
        public List<SeminarTbl> DeleteSeminar(short code);
    }
}
