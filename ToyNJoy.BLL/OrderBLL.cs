using Microsoft.EntityFrameworkCore.Storage;
using ToyNJoy.DAL;
using ToyNJoy.Entity.Model;
using ToyNJoy.Entity;
using ToyNJoy.Utiliy;

namespace ToyNJoy.BLL
{
    public class OrderBLL
    {
        private OrderDAL orderDAL;
        private OrderItemDAL orderItemDAL;
        private ShoppingCarDAL shoppingCarDAL;
        private ToyNjoyContext context;

        public OrderBLL(ToyNjoyContext context) 
        {
            this.context = context;
            orderDAL = new OrderDAL(context);
            orderItemDAL = new OrderItemDAL(context);
            shoppingCarDAL = new ShoppingCarDAL(context);
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
        public IEnumerable<Order> find(string? orderId, string? username, int? minTotalAmount, int? maxTotalAmount,
            int? state, DateTime? date, int? page, int? count)
        {
            return orderDAL.find(orderId, username, minTotalAmount, maxTotalAmount, state, date, page, count);
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
        public int findCount(string? orderId, string? username, int? minTotalAmount, int? maxTotalAmount,
            int? state, DateTime? date)
        {
            return orderDAL.findCount(orderId, username, minTotalAmount, maxTotalAmount, state, date);
        }

        /// <summary>
        /// 获取订单
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public Order get(string id)
        {
            return orderDAL.get(id);
        }

        /// <summary>
        /// 创建订单（通过购物车创建）
        /// </summary>
        /// <param name="username">用户名（主键）</param>
        /// <returns></returns>
        public string add(string username)
        {
            string result = "";

            IEnumerable<ShoppingCar> shoppingCar = shoppingCarDAL.find(username, null);

            Order order = new Order();
            order.Id = BaseUtiliy.GenerateOrderId();
            order.Username = username;
            order.TotalAmount = shoppingCar.Sum(s => s.Product.Price * s.Product.Discount);
            order.State = 0;
            order.CreateDate = DateTime.Now;

            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (ShoppingCar item in shoppingCar)
            {
                OrderItem orderItem = new OrderItem();
                orderItem.OrderId = order.Id;
                orderItem.ProductId = item.ProductId;
                orderItem.OriginalPrices = item.Product.Price;
                orderItem.Discount = item.Product.Discount;
                orderItem.Payment = item.Product.Price * item.Product.Discount;
                orderItems.Add(orderItem);
            }

            using (IDbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    // 创建支付宝订单，获取跳转支付页面的表单
                    if (order.TotalAmount > 0)
                    {
                        order.AlipayForm = new AlipayHelper().getPayForm(order.Id, "ToyNJoy", order.TotalAmount.Value.ToString("f2"), "测试");
                        result = order.AlipayForm;
                    }
                    else 
                    {
                        result = "oid" + order.Id;
                    }
                    orderDAL.add(order);
                    orderItemDAL.add(orderItems);
                    shoppingCarDAL.del(username);

                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                }
            }
            return result;
        }

        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="order">订单实体</param>
        /// <returns></returns>
        public bool upd(Order order)
        {
            return orderDAL.upd(order);
        }

        /// <summary>
        /// 获取订单详情
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <param name="hasProduct">是否带商品信息</param>
        /// <returns></returns>
        public IEnumerable<OrderItem> findItems(string? orderId, int? productId, string? username, bool? hasProduct)
        {
            return orderItemDAL.find(orderId, productId, username, hasProduct);
        } 
    }
}
