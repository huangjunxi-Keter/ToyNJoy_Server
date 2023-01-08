using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class LibraryGroup
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string GroupName { get; set; } = null!;

    public virtual ICollection<Library> Libraries { get; } = new List<Library>();

    public virtual User UserNameNavigation { get; set; } = null!;
}
