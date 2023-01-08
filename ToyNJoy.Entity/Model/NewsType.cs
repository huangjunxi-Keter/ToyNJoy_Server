using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class NewsType
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<News> News { get; } = new List<News>();
}
