using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class StudentsTbl
{
    public short StudentCode { get; set; }

    public string StudentId { get; set; } = null!;

    public string? StudentFatherCellPhoneNumber { get; set; }

    public string? StudentMotherCellPhoneNumber { get; set; }

    public short SeminarCode { get; set; }

    public DateTime StudentYearOfStartingSchool { get; set; }

    public string StudentGrade { get; set; } = null!;

    public short? StudentClassNumber { get; set; }

    public short? StudentFirstMajorCode { get; set; }

    public short? StudentSecondMajorCode { get; set; }

    public bool StudentLearnedFirstAid { get; set; }

    public bool StudentIsStudyingTeaching { get; set; }

    public short? StudentTeachingGuideCode { get; set; }

    public string? StudentMessageBox { get; set; }

    public virtual ICollection<AttendencePerCourseTbl> AttendencePerCourseTbls { get; } = new List<AttendencePerCourseTbl>();

    public virtual ICollection<MarkPerCourseTbl> MarkPerCourseTbls { get; } = new List<MarkPerCourseTbl>();

    public virtual SeminarTbl SeminarCodeNavigation { get; set; } = null!;

    public virtual UserTbl Student { get; set; } = null!;

    public virtual MajorTbl? StudentFirstMajorCodeNavigation { get; set; }

    public virtual MajorTbl? StudentSecondMajorCodeNavigation { get; set; }

    public virtual StaffTbl? StudentTeachingGuideCodeNavigation { get; set; }
}
