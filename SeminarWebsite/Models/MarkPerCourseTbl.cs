using System;
using System.Collections.Generic;

namespace SeminarWebsite.Models;

public partial class MarkPerCourseTbl
{
    public short MarkCodeForTheCourse { get; set; }

    public short CourseCodeForTheMajor { get; set; }

    public short StudentCode { get; set; }

    public double? MarkFirstHalf { get; set; }

    public double? MarkSecondHalf { get; set; }

    public double? MarkFinal { get; set; }

    public virtual MajorCoursesTbl CourseCodeForTheMajorNavigation { get; set; } = null!;

    public virtual StudentsTbl StudentCodeNavigation { get; set; } = null!;
}
