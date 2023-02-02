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
