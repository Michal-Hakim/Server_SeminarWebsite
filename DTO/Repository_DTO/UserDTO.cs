using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository_DTO
{
    public class UserDTO
    {
        public string UserId { get; set; } = null!;

        public string UserFirstName { get; set; } = null!;

        public string UserLastName { get; set; } = null!;

        public string? UserAddress { get; set; }

        public string? UserLocationCity { get; set; }

        public string? UserHomePhoneNumber { get; set; }

        public string? UserCellPhoneNumber { get; set; }

        public string? UserHebrewDateOfBirth { get; set; }

        public DateTime? UserEnglishDateOfBirth { get; set; }

        public string UserPassword { get; set; } = null!;

    }
}
