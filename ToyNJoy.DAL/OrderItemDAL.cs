using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace ToyNJoy.DAL
{
    public class OrderItemDAL
    {
        private ToyNjoyContext context;

        public OrderItemDAL(ToyNjoyContext context)
        {
            this.context = context;
        }

        public IEnumerable<OrderItem> find(string? orderId, int? productId = null, string? username = null, bool? hasProduct = null)
        {
            IQueryable<OrderItem> result = context.OrderItems;
            if (!string.IsNullOrEmpty(orderId))
                result = result.Where(x => x.OrderId == orderId);
            if (productId != null)
                result = result.Where(x => x.ProductId == productId);
            if (!string.IsNullOrEmpty(username))
                result = result.Where(o => o.Order.Username.Equals(username));
            if (hasProduct != null && hasProduct.Value)
                result = result.Include(o => o.Product);
            return result;
        }

        public OrderItem get(int id)
        {
            return context.OrderItems.Find(id);
        }

        public bool add(OrderItem orderItem)
        {
            context.OrderItems.Add(orderItem);
            return context.SaveChanges() > 0;
        }

        public bool add(List<OrderItem> orderItems)
        {
            foreach (OrderItem orderItem in orderItems)
            {
                context.OrderItems.Add(orderItem);
            }

            return context.SaveChanges() >= orderItems.Count();
        }

        public bool upd(OrderItem orderItem)
        {
            context.OrderItems.Update(orderItem);
            return context.SaveChanges() > 0;
        }
    }
}
