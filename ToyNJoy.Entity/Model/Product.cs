using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class Product
{
    public int Id { get; set; }

    public int TypeId { get; set; }

    public string Name { get; set; } = null!;

    public string Image { get; set; } = null!;

    public decimal Price { get; set; }

    public string Intro { get; set; } = null!;

    public int AgeGrading { get; set; }

    public string Developers { get; set; } = null!;

    public string Publisher { get; set; } = null!;

    public DateTime ReleaseDate { get; set; }

    public int Browse { get; set; }

    public int Purchases { get; set; }

    // public virtual ICollection<Library> Libraries { get; } = new List<Library>();

    public virtual ICollection<ProductHardwareRequirement> ProductHardwareRequirements { get; } = new List<ProductHardwareRequirement>();

    public virtual ICollection<ProductPhotoGallery> ProductPhotoGalleries { get; } = new List<ProductPhotoGallery>();

    public virtual ICollection<ShoppingCar> ShoppingCars { get; } = new List<ShoppingCar>();

    public virtual ProductType Type { get; set; } = null!;

    // public virtual ICollection<WishList> WishLists { get; } = new List<WishList>();
}
