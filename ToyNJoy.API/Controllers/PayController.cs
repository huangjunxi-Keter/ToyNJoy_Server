using Microsoft.AspNetCore.Mvc;
using ToyNJoy.Utiliy;

namespace ToyNJoy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PayController : Controller
    {
        private readonly ILogger<PayController> _logger;
        private readonly TokenHelper _tokenHelper;

        public PayController(ILogger<PayController> logger, TokenHelper tokenHelper)
        {
            _logger = logger;
            _tokenHelper = tokenHelper;
        }

        private AlipayHelper alipay = new AlipayHelper();

        [HttpPost("getPayForm")]
        public string getPayForm() 
        {
            //（！！！AdGuard 广告拦截器 会影响沙箱支付宝 使其支付后出现【系统有点忙】错误！！！）
            return alipay.getPayForm("202313123081", "ToyNJoy", "100", "测试");
        }
    }
}
