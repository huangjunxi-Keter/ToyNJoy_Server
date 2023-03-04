using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class NewsType
{
    /// <summary>
    /// 主键
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    /// 类型名
    /// </summary>
    public string? TypeName { get; set; } = null!;

    /// <summary>
    /// 状态：0停用 1启用
    /// </summary>
    public int? State { get; set; }

    public virtual ICollection<News> News { get; } = new List<News>();
}
