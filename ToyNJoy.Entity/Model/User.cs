using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class User
{
    /// <summary>
    /// 主键（用户名）
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    public string? Nickname { get; set; }

    /// <summary>
    /// 等级
    /// </summary>
    public int? Lv { get; set; }

    /// <summary>
    /// 头像
    /// </summary>
    public string? VirtualImage { get; set; }

    /// <summary>
    /// 注册时间
    /// </summary>
    public DateTime? RegisterTime { get; set; }

    /// <summary>
    /// 状态 0禁用 1启用
    /// </summary>
    public int? State { get; set; }

    /// <summary>
    /// 类型Id
    /// </summary>
    public int? TypeId { get; set; }

    public virtual ICollection<Friend> FriendFriendNameNavigations { get; } = new List<Friend>();

    public virtual ICollection<FriendGroup> FriendGroups { get; } = new List<FriendGroup>();

    public virtual ICollection<Friend> FriendUserNameNavigations { get; } = new List<Friend>();

    public virtual ICollection<Library> Libraries { get; } = new List<Library>();

    public virtual ICollection<LibraryGroup> LibraryGroups { get; } = new List<LibraryGroup>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<ShoppingCar> ShoppingCars { get; } = new List<ShoppingCar>();

    public virtual ICollection<UserInfo> UserInfos { get; } = new List<UserInfo>();

    public virtual ICollection<WishList> WishLists { get; } = new List<WishList>();
}
