using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class CoursesTbl
{
    public short CourseCode { get; set; }

    public string CourseName { get; set; } = null!;

    public virtual ICollection<MajorCoursesTbl> MajorCoursesTbls { get; } = new List<MajorCoursesTbl>();
}
