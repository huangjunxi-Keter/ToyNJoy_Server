using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class UserInfo
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Signature { get; set; } = null!;

    public string WrapperImage { get; set; } = null!;

    public string? Gender { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Idcard { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public virtual User UserNameNavigation { get; set; } = null!;
}
