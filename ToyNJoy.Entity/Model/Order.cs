﻿using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class Order
{
    /// <summary>
    /// 主键
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// 总价
    /// </summary>
    public double? TotalAmount { get; set; }

    /// <summary>
    /// 状态 0未支付 1支付
    /// </summary>
    public int? State { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CreateDate { get; set; }


    public string? AlipayData { get; set; }

    // public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

    public virtual User? UsernameNavigation { get; set; }
}
