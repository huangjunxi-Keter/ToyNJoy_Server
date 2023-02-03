using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyNJoy.Entity
{
    public class Alipay
    {
        public string? app_id { get; set; }
        public string? auth_app_id { get; set; }
        public string? charset { get; set; }
        public string? method { get; set; }
        public string? out_trade_no { get; set; }
        public string? seller_id { get; set; }
        public string? sign { get; set; }
        public string? sign_type { get; set; }
        public string? timestamp { get; set; }
        public string? total_amount { get; set; }
        public string? trade_no { get; set; }
        public string? version { get; set; }
    }
}
