using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class News
{
    /// <summary>
    /// 主键
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 分类
    /// </summary>
    public int TypeId { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// 内容
    /// </summary>
    public string Text { get; set; } = null!;

    /// <summary>
    /// 浏览量
    /// </summary>
    public int PageView { get; set; }

    /// <summary>
    /// 点赞
    /// </summary>
    public int Commend { get; set; }

    /// <summary>
    /// 点踩
    /// </summary>
    public int Trample { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime UpdateTime { get; set; }

    /// <summary>
    /// 封面
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    /// 相关产品id
    /// </summary>
    public int? ProductId { get; set; }

    public virtual NewsType Type { get; set; } = null!;
}
