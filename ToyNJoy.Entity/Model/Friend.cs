using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class Friend
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string FriendName { get; set; } = null!;

    public string? Nickname { get; set; }

    public int State { get; set; }

    public int? GroupId { get; set; }

    public virtual User FriendNameNavigation { get; set; } = null!;

    public virtual FriendGroup? Group { get; set; }

    public virtual User UserNameNavigation { get; set; } = null!;
}
