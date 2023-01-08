using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class News
{
    public int Id { get; set; }

    public int TypeId { get; set; }

    public string Title { get; set; } = null!;

    public string Text { get; set; } = null!;

    public int PageView { get; set; }

    public int Commend { get; set; }

    public int Trample { get; set; }

    public DateTime UpdateTime { get; set; }

    public string? Image { get; set; }

    public int? ProductId { get; set; }

    public virtual NewsType Type { get; set; } = null!;
}
