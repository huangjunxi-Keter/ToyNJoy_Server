using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class ProductType
{
    /// <summary>
    /// 主键
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    /// 类型名称
    /// </summary>
    public string? TypeName { get; set; }

    /// <summary>
    /// 类型状态：0停用 1启用
    /// </summary>
    public int? State { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
