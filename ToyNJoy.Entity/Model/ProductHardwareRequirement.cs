using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class ProductHardwareRequirement
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string Os { get; set; } = null!;

    public string Os1 { get; set; } = null!;

    public string Cpu { get; set; } = null!;

    public string Cpu1 { get; set; } = null!;

    public string Ram { get; set; } = null!;

    public string Ram1 { get; set; } = null!;

    public string Gpu { get; set; } = null!;

    public string Gpu1 { get; set; } = null!;

    public string DirectX { get; set; } = null!;

    public string DirectX1 { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
