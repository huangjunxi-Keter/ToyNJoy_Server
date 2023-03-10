using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class WishList
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
    /// 商品id
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 排序顺序
    /// </summary>
    public int SerialNamber { get; set; }

    /// <summary>
    /// 添加时间
    /// </summary>
    public DateTime JoinDate { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User UserNameNavigation { get; set; } = null!;
}
