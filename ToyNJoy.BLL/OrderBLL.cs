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

        public Order get(string id)
        {
            return orderDAL.get(id);
        }

        public string add(string username)
        {
            string result = null;

            IEnumerable<ShoppingCar> shoppingCar = shoppingCarDAL.find(username, null);

            Order order = new Order();
            order.Id = BaseUtiliy.GenerateOrderId();
            order.Username = username;
            order.TotalAmount = shoppingCar.Sum(l => l.Product.Price * l.Product.Discount);
            order.State = 0;
            order.CreateDate = DateTime.Now;

            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (ShoppingCar item in shoppingCar)
            {
                OrderItem orderItem = new OrderItem();
                orderItem.OrderId = order.Id;
                orderItem.ProductId = item.ProductId;
                orderItem.Price = item.Product.Price * item.Product.Discount;
                orderItems.Add(orderItem);
            }

            using (IDbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    orderDAL.add(order);
                    orderItemDAL.add(orderItems);

                    dbContextTransaction.Commit();

                    // 创建支付宝订单，获取跳转支付页面的表单
                    result = new AlipayHelper().getPayForm(order.Id, "ToyNJoy", order.TotalAmount.Value.ToString("f2"), "测试");
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                }
            }
            return result;
        }

        public bool upd(Order order)
        {
            return orderDAL.upd(order);
        }
    }
}
