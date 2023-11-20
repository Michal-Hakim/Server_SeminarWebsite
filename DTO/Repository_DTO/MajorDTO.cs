using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository_DTO
{
    public class MajorDTO
    {
        public short MajorCode { get; set; }

        public string MajorName { get; set; } = null!;

        public short MajorCodeCoordinator { get; set; }

        public short SeminarCode { get; set; }

    }
}
