using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class Product
{
    /// <summary>
    /// 主键
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 类型id
    /// </summary>
    public int TypeId { get; set; }

    /// <summary>
    /// 商品名
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 商品封面
    /// </summary>
    public string Image { get; set; } = null!;

    /// <summary>
    /// 价格
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// 介绍
    /// </summary>
    public string Intro { get; set; } = null!;

    /// <summary>
    /// 年龄分级
    /// </summary>
    public int AgeGrading { get; set; }

    /// <summary>
    /// 开发商
    /// </summary>
    public string Developers { get; set; } = null!;

    /// <summary>
    /// 发行商
    /// </summary>
    public string Publisher { get; set; } = null!;

    /// <summary>
    /// 发行时间
    /// </summary>
    public DateTime ReleaseDate { get; set; }

    /// <summary>
    /// 浏览量
    /// </summary>
    public int Browse { get; set; }

    /// <summary>
    /// 销量
    /// </summary>
    public int Purchases { get; set; }

    /// <summary>
    /// 折扣
    /// </summary>
    public double Discount { get; set; }

    // public virtual ICollection<Library> Libraries { get; } = new List<Library>();

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

    public virtual ICollection<ProductHardwareRequirement> ProductHardwareRequirements { get; } = new List<ProductHardwareRequirement>();

    public virtual ICollection<ProductPhotoGallery> ProductPhotoGalleries { get; } = new List<ProductPhotoGallery>();

    // public virtual ICollection<ShoppingCar> ShoppingCars { get; } = new List<ShoppingCar>();

    public virtual ProductType Type { get; set; } = null!;

    // public virtual ICollection<WishList> WishLists { get; } = new List<WishList>();
}
