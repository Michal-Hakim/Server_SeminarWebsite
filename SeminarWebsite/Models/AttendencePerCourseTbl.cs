using System;
using System.Collections.Generic;

namespace SeminarWebsite.Models;

public partial class AttendencePerCourseTbl
{
    public short AttendenceCodeForTheCourse { get; set; }

    public short LessonCode { get; set; }

    public short StudentCode { get; set; }

    public bool StudentPresentInLesson { get; set; }

    public virtual ExistedLessonsTbl LessonCodeNavigation { get; set; } = null!;

    public virtual StudentsTbl StudentCodeNavigation { get; set; } = null!;
}
