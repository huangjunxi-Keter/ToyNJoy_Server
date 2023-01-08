using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class FriendGroup
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string GroupName { get; set; } = null!;

    public virtual ICollection<Friend> Friends { get; } = new List<Friend>();

    public virtual User UserNameNavigation { get; set; } = null!;
}
