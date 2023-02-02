using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class LibraryGroup
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

    public virtual ICollection<Library> Libraries { get; } = new List<Library>();

    public virtual User UserNameNavigation { get; set; } = null!;
}
