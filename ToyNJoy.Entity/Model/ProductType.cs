using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class ProductType
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
