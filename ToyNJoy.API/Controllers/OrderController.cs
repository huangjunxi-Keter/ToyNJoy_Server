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
            string token = Request.Headers["Authorization"].ToString().Split(' ')[1];
            User user = tokenHelper.GetToken<User>(token);
            return bll.add(user.Username);
        }
    }
}
