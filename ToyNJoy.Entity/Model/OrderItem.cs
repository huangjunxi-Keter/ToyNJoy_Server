using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class OrderItem
{
    /// <summary>
    /// 主键
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 订单id
    /// </summary>
    public string OrderId { get; set; } = null!;

    /// <summary>
    /// 商品id
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 原价
    /// </summary>
    public double? OriginalPrices { get; set; }

    /// <summary>
    /// 折扣
    /// </summary>
    public double? Discount { get; set; }

    /// <summary>
    /// 实付（根据商品价格和折扣计算）
    /// </summary>
    public double? Payment { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
