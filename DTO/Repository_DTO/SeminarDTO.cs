using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository_DTO
{
    public class SeminarDTO
    {
        public short SeminarCode { get; set; }

        public string SeminarName { get; set; } = null!;

        public string? SeminarAddress { get; set; }

        public string? SeminarLocationCity { get; set; }

        public string? SeminarPhoneNumber { get; set; }

        public string? SeminarFaxNumber { get; set; }

        public string? SeminarEmailAddress { get; set; }

        public string? SeminarLogo { get; set; }

        public string SeminarManagerPassword { get; set; } = null!;

        public bool SeminarStatus { get; set; }
    }
}
