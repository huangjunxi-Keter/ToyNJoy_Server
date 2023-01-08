using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class Library
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public int ProductId { get; set; }

    public DateTime JoinTime { get; set; }

    public DateTime LastTime { get; set; }

    public int TotalHours { get; set; }

    public int? GroupId { get; set; }

    public virtual LibraryGroup? Group { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User UserNameNavigation { get; set; } = null!;
}
