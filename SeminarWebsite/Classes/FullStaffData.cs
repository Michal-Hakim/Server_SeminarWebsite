namespace SeminarWebsite.Classes
{
    public class FullStaffData
    {
        public string UserId { get; set; } = null!;

        public string UserPassword { get; set; } = null!;

        public string UserFirstName { get; set; } = null!;

        public string UserLastName { get; set; } = null!;

        public string? UserHomePhoneNumber { get; set; }

        public string? UserCellPhoneNumber { get; set; }

        public string? UserHebrewDateOfBirth { get; set; }

        public DateTime? UserEnglishDateOfBirth { get; set; }

        public string? UserAddress { get; set; }

        public string? UserLocationCity { get; set; }

        public short StaffCode { get; set; }

        public string StaffMemberPosition { get; set; } = null!;

        public DateTime? StaffEmploymentStartDate { get; set; }

        public bool StaffStatus { get; set; }

        public short SeminarCode { get; set; }

    }
}
