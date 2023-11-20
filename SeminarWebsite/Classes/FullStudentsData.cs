namespace SeminarWebsite.Classes
{
    public class FullStudentsData
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

        public string? StudentFatherCellPhoneNumber { get; set; }

        public string? StudentMotherCellPhoneNumber { get; set; }

        public string SeminarName { get; set; }

        public DateTime StudentYearOfStartingSchool { get; set; }

        public string StudentGrade { get; set; }

        public short? StudentClassNumber { get; set; }

        public string StudentFirstMajorName { get; set; }

        public string StudentSecondMajorName { get; set; }

        public bool StudentLearnedFirstAid { get; set; }

        public bool StudentIsStudyingTeaching { get; set; }

        public string StudentTeachingGuideName { get; set; }
    }
}
