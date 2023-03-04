using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.DAL
{
    public class OrderDAL
    {
        private ToyNjoyContext context;

        public OrderDAL(ToyNjoyContext context)
        {
            this.context = context;
        }

        public IEnumerable<Order> find(string? orderId, string? username, int? minTotalAmount, int? maxTotalAmount, 
            int? state, DateTime? date, int? page, int? count)
        {
            IEnumerable<Order> result = context.Orders;
            if (!string.IsNullOrEmpty(orderId))
                result = result.Where(o => o.Id.Contains(orderId));
            if (!string.IsNullOrEmpty(username))
                result = result.Where(o => o.Username.Contains(username));
            if (minTotalAmount != null)
                result = result.Where(o => o.TotalAmount >= minTotalAmount);
            if (maxTotalAmount != null)
                result = result.Where(o => o.TotalAmount <= maxTotalAmount);
            if (state != null)
                result = result.Where(o => o.State == state);
            if (date != null)
            {
                DateTime min = date.Value.AddDays(-1);
                DateTime max = date.Value.AddDays(1);

                result = result.Where(o => o.CreateDate > min && o.CreateDate < max);
            }

            if (page != null && count != null)
                result = result.Skip((page * count).Value);
            if (count != null)
                result = result.Take(count.Value);

            return result;
        }

        public int findCount(string? orderId, string? username, int? minTotalAmount, int? maxTotalAmount, int? state, DateTime? date)
        {
            IEnumerable<Order> orders = context.Orders;
            if (!string.IsNullOrEmpty(orderId))
                orders = orders.Where(o => o.Id.Contains(orderId));
            if (!string.IsNullOrEmpty(username))
                orders = orders.Where(o => o.Username.Contains(username));
            if (minTotalAmount != null)
                orders = orders.Where(o => o.TotalAmount >= minTotalAmount);
            if (maxTotalAmount != null)
                orders = orders.Where(o => o.TotalAmount <= maxTotalAmount);
            if (state != null)
                orders = orders.Where(o => o.State == state);
            if (date != null)
            {
                DateTime min = date.Value.AddDays(-1);
                DateTime max = date.Value.AddDays(1);

                orders = orders.Where(o => o.CreateDate > min && o.CreateDate < max);
            }

            return orders.Count();
        }

        public Order get(string id)
        {
            return context.Orders.Find(id);
        }

        public bool add(Order order)
        {
            context.Orders.Add(order);
            return context.SaveChanges() > 0;
        }

        public bool upd(Order order)
        {
            context.Orders.Update(order);
            return context.SaveChanges() > 0;
        }
    }
}
