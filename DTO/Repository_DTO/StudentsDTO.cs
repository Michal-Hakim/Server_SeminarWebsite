using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository_DTO
{
    public class StudentsDTO
    {
        public short StudentCode { get; set; }

        public string StudentId { get; set; } = null!;

        public string? StudentFatherCellPhoneNumber { get; set; }

        public string? StudentMotherCellPhoneNumber { get; set; }

        public string StudentGrade { get; set; } = null!;

        public short? StudentClassNumber { get; set; }

        public short? StudentFirstMajorCode { get; set; }

        public short? StudentSecondMajorCode { get; set; }

        public bool StudentLearnedFirstAid { get; set; }

        public bool StudentIsStudyingTeaching { get; set; }

        public short? StudentTeachingGuideCode { get; set; }

        public DateTime StudentYearOfStartingSchool { get; set; }

        public short SeminarCode { get; set; }
    }
}
