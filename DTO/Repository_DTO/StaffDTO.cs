using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository_DTO
{
    public class StaffDTO
    {
        public short StaffCode { get; set; }

        public string StaffId { get; set; } = null!;

        public string StaffMemberPosition { get; set; } = null!;

        public DateTime? StaffEmploymentStartDate { get; set; }

        public bool StaffStatus { get; set; }

        public short SeminarCode { get; set; }
    }
}
