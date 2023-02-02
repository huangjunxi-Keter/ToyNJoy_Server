using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class Friend
{
    /// <summary>
    /// 主键
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; } = null!;

    /// <summary>
    /// 好友 用户名
    /// </summary>
    public string FriendName { get; set; } = null!;

    /// <summary>
    /// 好友 备注
    /// </summary>
    public string? Nickname { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public int State { get; set; }

    /// <summary>
    /// 分组id
    /// </summary>
    public int? GroupId { get; set; }

    public virtual User FriendNameNavigation { get; set; } = null!;

    public virtual FriendGroup? Group { get; set; }

    public virtual User UserNameNavigation { get; set; } = null!;
}
