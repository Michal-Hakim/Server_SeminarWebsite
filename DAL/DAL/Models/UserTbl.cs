using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class UserTbl
{
    public string UserId { get; set; } = null!;

    public string UserFirstName { get; set; } = null!;

    public string UserLastName { get; set; } = null!;

    public string? UserAddress { get; set; }

    public string? UserLocationCity { get; set; }

    public string? UserHomePhoneNumber { get; set; }

    public string? UserCellPhoneNumber { get; set; }

    public string? UserHebrewDateOfBirth { get; set; }

    public DateTime? UserEnglishDateOfBirth { get; set; }

    public string UserPassword { get; set; } = null!;

    public virtual ICollection<StaffTbl> StaffTbls { get; } = new List<StaffTbl>();

    public virtual ICollection<StudentsTbl> StudentsTbls { get; } = new List<StudentsTbl>();
}
