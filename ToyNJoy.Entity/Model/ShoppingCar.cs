using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class ShoppingCar
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User UserNameNavigation { get; set; } = null!;
}
