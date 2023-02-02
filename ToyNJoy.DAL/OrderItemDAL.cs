using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.DAL
{
    public class OrderItemDAL
    {
        private ToyNjoyContext context;

        public OrderItemDAL(ToyNjoyContext context)
        {
            this.context = context;
        }

        public IEnumerable<OrderItem> find(string orderId)
        {
            return context.OrderItems.Where(o => o.OrderId.Equals(orderId));
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
