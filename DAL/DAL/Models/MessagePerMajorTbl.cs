using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class MessagePerMajorTbl
{
    public short MessageCode { get; set; }

    public short MajorCode { get; set; }

    public short StaffCode { get; set; }

    public string? MessageContent { get; set; }

    public DateTime? MessageDate { get; set; }

    public virtual MajorTbl MajorCodeNavigation { get; set; } = null!;

    public virtual StaffTbl StaffCodeNavigation { get; set; } = null!;
}
