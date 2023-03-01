using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class ProductHardwareRequirement
{
    public ProductHardwareRequirement() { }

    public ProductHardwareRequirement(int productId, string initialStr) 
    {
        this.ProductId = productId;
        this.Os = initialStr;
        this.Os1 = initialStr;
        this.Cpu = initialStr;
        this.Cpu1 = initialStr;
        this.Ram = initialStr;
        this.Ram1 = initialStr;
        this.Gpu = initialStr;
        this.Gpu1 = initialStr;
        this.DirectX = initialStr;
        this.DirectX1 = initialStr;
    }

    /// <summary>
    /// 主键
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 产品id
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 标准配置 系统
    /// </summary>
    public string Os { get; set; } = null!;

    /// <summary>
    /// 推荐配置 系统
    /// </summary>
    public string Os1 { get; set; } = null!;

    /// <summary>
    /// 标准配置 处理器
    /// </summary>
    public string Cpu { get; set; } = null!;

    /// <summary>
    /// 推荐配置 处理器
    /// </summary>
    public string Cpu1 { get; set; } = null!;

    /// <summary>
    /// 标准配置 运行内存
    /// </summary>
    public string Ram { get; set; } = null!;

    /// <summary>
    /// 推荐配置 运行内存
    /// </summary>
    public string Ram1 { get; set; } = null!;

    /// <summary>
    /// 标准配置 显卡
    /// </summary>
    public string Gpu { get; set; } = null!;

    /// <summary>
    /// 推荐配置 显卡
    /// </summary>
    public string Gpu1 { get; set; } = null!;

    /// <summary>
    /// 标准配置 DX版本
    /// </summary>
    public string DirectX { get; set; } = null!;

    /// <summary>
    /// 推荐配置 DX版本
    /// </summary>
    public string DirectX1 { get; set; } = null!;

    public virtual Product? Product { get; set; }
}
