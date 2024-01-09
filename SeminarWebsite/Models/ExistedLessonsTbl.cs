using System;
using System.Collections.Generic;

namespace SeminarWebsite.Models;

public partial class ExistedLessonsTbl
{
    public short LessonCode { get; set; }

    public short CourseCodeForTheMajor { get; set; }

    public DateTime? LessonDate { get; set; }

    public short? LessonTime { get; set; }

    public virtual ICollection<AttendencePerCourseTbl> AttendencePerCourseTbls { get; } = new List<AttendencePerCourseTbl>();

    public virtual MajorCoursesTbl CourseCodeForTheMajorNavigation { get; set; } = null!;
}
