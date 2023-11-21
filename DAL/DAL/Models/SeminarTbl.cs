using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class SeminarTbl
{
    public short SeminarCode { get; set; }

    public string SeminarName { get; set; } = null!;

    public string? SeminarAddress { get; set; }

    public string? SeminarLocationCity { get; set; }

    public string? SeminarPhoneNumber { get; set; }

    public string? SeminarFaxNumber { get; set; }

    public string? SeminarEmailAddress { get; set; }

    public string SeminarManagerPassword { get; set; } = null!;

    public bool SeminarStatus { get; set; }

    public virtual ICollection<MajorTbl> MajorTbls { get; } = new List<MajorTbl>();

    public virtual ICollection<StaffTbl> StaffTbls { get; } = new List<StaffTbl>();

    public virtual ICollection<StudentsTbl> StudentsTbls { get; } = new List<StudentsTbl>();
}
