using DAL.Models;
using DTO.Repository_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISeminarBLL
    {
        //Get
        public List<SeminarDTO> GetAllSeminars();
        public SeminarDTO GetSeminarBySeminarCode(int code);
        public SeminarDTO GetSeminarBySeminarEmailAddress(string seminarEmailAddress);
        //public SeminarDTO GetSeminarBySeminarManagerCode(string managerCode);
        //public List<SeminarDTO> GetSeminarsBySeminarStatus(bool status);

        //Put
        public List<SeminarDTO> UpdateSeminar(short code, SeminarDTO seminarDTO);

        //Post
        public SeminarDTO AddSeminar(SeminarDTO seminarDTO);

        //Delete
        public List<SeminarDTO> DeleteSeminar(short code);
    }
}
