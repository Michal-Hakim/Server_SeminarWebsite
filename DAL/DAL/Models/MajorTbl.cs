using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class MajorTbl
{
    public short MajorCode { get; set; }

    public string MajorName { get; set; } = null!;

    public short MajorCodeCoordinator { get; set; }

    public short SeminarCode { get; set; }

    public virtual StaffTbl MajorCodeCoordinatorNavigation { get; set; } = null!;

    public virtual ICollection<MajorCoursesTbl> MajorCoursesTbls { get; } = new List<MajorCoursesTbl>();

    public virtual ICollection<MessagePerMajorTbl> MessagePerMajorTbls { get; } = new List<MessagePerMajorTbl>();

    public virtual SeminarTbl SeminarCodeNavigation { get; set; } = null!;

    public virtual ICollection<StudentsTbl> StudentsTblStudentFirstMajorCodeNavigations { get; } = new List<StudentsTbl>();

    public virtual ICollection<StudentsTbl> StudentsTblStudentSecondMajorCodeNavigations { get; } = new List<StudentsTbl>();
}
