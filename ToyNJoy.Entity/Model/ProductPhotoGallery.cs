using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class ProductPhotoGallery
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string Image { get; set; } = null!;

    public DateTime JoinDate { get; set; }

    public virtual Product Product { get; set; } = null!;
}
