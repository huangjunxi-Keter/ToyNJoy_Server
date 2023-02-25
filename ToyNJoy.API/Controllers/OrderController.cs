using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;
using ToyNJoy.BLL;
using ToyNJoy.Utiliy;

namespace ToyNJoy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> logger;
        private OrderBLL bll;
        private TokenHelper tokenHelper;

        public OrderController(ILogger<OrderController> logger,ToyNjoyContext context, TokenHelper tokenHelper)
        {
            this.logger = logger;
            bll = new OrderBLL(context);
            this.tokenHelper = tokenHelper;
        }

        /// <summary>
        /// 获取可跳转到支付页面的表单
        /// </summary>
        /// <returns></returns>
        [HttpPost("add")]
        [Authorize]
        public string add() 
        {
            User loginUser = BaseUtiliy.getTokenData<User>(Request, tokenHelper);
            return bll.add(loginUser.Username);
        }
    }
}
