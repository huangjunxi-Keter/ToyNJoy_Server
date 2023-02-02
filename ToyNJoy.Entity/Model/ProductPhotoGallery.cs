using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class ProductPhotoGallery
{
    /// <summary>
    /// 主键
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 商品id
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 图片名称
    /// </summary>
    public string Image { get; set; } = null!;

    /// <summary>
    /// 添加日期
    /// </summary>
    public DateTime JoinDate { get; set; }

    public virtual Product Product { get; set; } = null!;
}
