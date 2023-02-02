using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class ProductType
{
    /// <summary>
    /// 主键
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 类型名称
    /// </summary>
    public string TypeName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
