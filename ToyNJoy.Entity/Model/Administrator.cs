using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class Administrator
{
    public int Id { get; set; }

    public string SaName { get; set; } = null!;

    public string SaPassword { get; set; } = null!;
}
