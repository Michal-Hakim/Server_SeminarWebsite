using DAL.Models;
using DTO.Repository_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMajorBLL
    {
        //Get
        public List<MajorDTO> GetAllMajors();
        public MajorDTO GetMajorByMajorCode(short majorCode);
        public MajorDTO GetMajorBySeminarCodeAndMajorCode(short seminarCode, short majorCode);
        public List<MajorDTO> GetMajorsBySeminarAndTeacherCode(short seminarCode, short staffCode);
        public List<MajorDTO> GetMajorBySeminarCode(short seminarCode);
        //public List<MajorDTO> GetMajorBySeminarCodeAndMajorCodeCoordinator(short seminarCode, short majorCodeCoordinator);
        //public List<MajorDTO> GetMajorBySeminarCodeAndMajorName(short seminarCode, string majorName);

        //Put
        //public List<MajorDTO> UpdateMajorByMajorCode(short majorCode);
        //public List<MajorDTO> UpdateMajorBySeminarCodeAndMajorName(short seminarCode, string majorName);
        //public List<MajorDTO> UpdateMajorBySeminarCodeAndMajorCodeCoordinator(short seminarCode, short majorCodeCoordinator);
        //public List<MajorDTO> UpdateMajorBySeminarCode(short seminarCode);

        //Post
        public MajorDTO AddMajor(MajorDTO majorDTO);

        //Delete
        //public List<MajorDTO> DeleteMajorByMajorCode(short majorCode);
    }
}
