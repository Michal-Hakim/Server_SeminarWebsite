using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class MajorCoursesTbl
{
    public short CourseCodeForTheMajor { get; set; }

    public short MajorCode { get; set; }

    public short CourseCode { get; set; }

    public short CourseTeacherCode { get; set; }

    public DateTime CourseStartYear { get; set; }

    public string CourseGrade { get; set; } = null!;

    public short CourseNumberOfWeeklyHours { get; set; }

    public virtual CoursesTbl CourseCodeNavigation { get; set; } = null!;

    public virtual StaffTbl CourseTeacherCodeNavigation { get; set; } = null!;

    public virtual ICollection<ExistedLessonsTbl> ExistedLessonsTbls { get; } = new List<ExistedLessonsTbl>();

    public virtual MajorTbl MajorCodeNavigation { get; set; } = null!;

    public virtual ICollection<MarkPerCourseTbl> MarkPerCourseTbls { get; } = new List<MarkPerCourseTbl>();
}
