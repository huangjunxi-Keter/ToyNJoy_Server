using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class FriendGroup
{
    /// <summary>
    /// 主键
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; } = null!;

    /// <summary>
    /// 分组名
    /// </summary>
    public string GroupName { get; set; } = null!;

    public virtual ICollection<Friend> Friends { get; } = new List<Friend>();

    public virtual User UserNameNavigation { get; set; } = null!;
}
