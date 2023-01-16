using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class User
{
    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Nickname { get; set; }

    public int? Lv { get; set; }

    public string? VirtualImage { get; set; }

    public DateTime? RegisterTime { get; set; }

    public int? State { get; set; }

    public virtual ICollection<Friend> FriendFriendNameNavigations { get; } = new List<Friend>();

    public virtual ICollection<FriendGroup> FriendGroups { get; } = new List<FriendGroup>();

    public virtual ICollection<Friend> FriendUserNameNavigations { get; } = new List<Friend>();

    public virtual ICollection<Library> Libraries { get; } = new List<Library>();

    public virtual ICollection<LibraryGroup> LibraryGroups { get; } = new List<LibraryGroup>();

    public virtual ICollection<ShoppingCar> ShoppingCars { get; } = new List<ShoppingCar>();

    public virtual ICollection<UserInfo> UserInfos { get; } = new List<UserInfo>();

    public virtual ICollection<WishList> WishLists { get; } = new List<WishList>();
}
