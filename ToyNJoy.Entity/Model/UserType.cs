using System;
using System.Collections.Generic;

namespace ToyNJoy.Entity.Model
{
    public partial class UserType
    {
        /// <summary>
        /// 主键 自增
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string? TypeName { get; set; }

        /// <summary>
        /// 状态：0禁用 1启用用
        /// </summary>
        public int? State { get; set; }
    }
}
