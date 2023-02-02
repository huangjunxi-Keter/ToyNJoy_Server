using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model;

public partial class Administrator
{
    /// <summary>
    /// 主键
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 账号
    /// </summary>
    public string SaName { get; set; } = null!;

    /// <summary>
    /// 密码
    /// </summary>
    public string SaPassword { get; set; } = null!;
}
