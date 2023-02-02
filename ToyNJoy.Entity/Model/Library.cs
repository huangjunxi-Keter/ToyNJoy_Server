using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class Library
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
    /// 商品主键
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 添加时间
    /// </summary>
    public DateTime JoinTime { get; set; }

    /// <summary>
    /// 最后操作时间
    /// </summary>
    public DateTime LastTime { get; set; }

    /// <summary>
    /// 总操作时间（运行时长）
    /// </summary>
    public int TotalHours { get; set; }

    /// <summary>
    /// 分组主键
    /// </summary>
    public int? GroupId { get; set; }

    public virtual LibraryGroup? Group { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User UserNameNavigation { get; set; } = null!;
}
