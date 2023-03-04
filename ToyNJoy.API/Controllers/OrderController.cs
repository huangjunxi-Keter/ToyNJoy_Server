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

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <param name="username">用户名（主键）</param>
        /// <param name="minTotalAmount">最小总价</param>
        /// <param name="maxTotalAmount">最大总价</param>
        /// <param name="state">状态 0 1 2</param>
        /// <param name="date">创建日期</param>
        /// <param name="page">当前页页数减一</param>
        /// <param name="count">总条数</param>
        /// <returns></returns>
        [HttpGet("find")]
        [Authorize]
        public IEnumerable<Order> find(string? orderId, string? username, int? minTotalAmount, int? maxTotalAmount,
            int? state, DateTime? date, int? page, int? count)
        {
            return bll.find(orderId, username, minTotalAmount, maxTotalAmount, state, date, page, count);
        }

        /// <summary>
        /// 订单总数
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <param name="username">用户名（主键）</param>
        /// <param name="minTotalAmount">最小总价</param>
        /// <param name="maxTotalAmount">最大总价</param>
        /// <param name="state">状态 0 1 2</param>
        /// <param name="date">创建日期</param>
        /// <returns></returns>
        [HttpGet("findCount")]
        [Authorize]
        public int findCount(string? orderId, string? username, int? minTotalAmount, int? maxTotalAmount,
            int? state, DateTime? date)
        {
            return bll.findCount(orderId, username, minTotalAmount, maxTotalAmount, state, date);
        }

        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="order">订单实体</param>
        /// <returns></returns>
        [HttpPost("upd")]
        [Authorize]
        public bool upd([FromBody] Order order)
        {
            return bll.upd(order);
        }

        /// <summary>
        /// 获取订单详情
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <param name="hasProduct">是否带商品信息</param>
        /// <returns></returns>
        [HttpGet("findItems")]
        [Authorize]
        public IEnumerable<OrderItem> findItems(string? orderId, bool? hasProduct)
        {
            return bll.findItems(orderId, hasProduct);
        }
    }
}
