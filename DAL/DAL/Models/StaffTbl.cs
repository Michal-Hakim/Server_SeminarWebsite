using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class StaffTbl
{
    public short StaffCode { get; set; }

    public string StaffId { get; set; } = null!;

    public string StaffMemberPosition { get; set; } = null!;

    public DateTime? StaffEmploymentStartDate { get; set; }

    public bool StaffStatus { get; set; }

    public short SeminarCode { get; set; }

    public virtual ICollection<MajorCoursesTbl> MajorCoursesTbls { get; } = new List<MajorCoursesTbl>();

    public virtual ICollection<MajorTbl> MajorTbls { get; } = new List<MajorTbl>();

    public virtual SeminarTbl SeminarCodeNavigation { get; set; } = null!;

    public virtual UserTbl Staff { get; set; } = null!;

    public virtual ICollection<StudentsTbl> StudentsTbls { get; } = new List<StudentsTbl>();
}
