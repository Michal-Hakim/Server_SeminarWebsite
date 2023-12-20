using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IMajorDAL
    {
        //Get
        public List<MajorTbl> GetAllMajors();
        public MajorTbl GetMajorByMajorCode(short majorCode);
        public MajorTbl GetMajorBySeminarCodeAndMajorCode(short seminarCode, short majorCode);
        public List<MajorTbl> GetMajorBySeminarCodeAndMajorName(short seminarCode, string majorName);
        public List<MajorTbl> GetMajorBySeminarCodeAndMajorCodeCoordinator(short seminarCode, short majorCodeCoordinator);
        public List<MajorTbl> GetMajorBySeminarCode(short seminarCode);
        public MajorTbl GetMajorByMajorName(string majorName);

        //Put
        //public List<MajorTbl> UpdateMajorByMajorCode(short majorCode);
        //public List<MajorTbl> UpdateMajorBySeminarCodeAndMajorName(short seminarCode, string majorName);
        //public List<MajorTbl> UpdateMajorBySeminarCodeAndMajorCodeCoordinator(short seminarCode, short majorCodeCoordinator);
        //public List<MajorTbl> UpdateMajorBySeminarCode(short seminarCode);

        //Post
        public MajorTbl AddMajor(MajorTbl majorTbl);

        //Delete
        public List<MajorTbl> DeleteMajorByMajorCode(short majorCode);

    }
}
