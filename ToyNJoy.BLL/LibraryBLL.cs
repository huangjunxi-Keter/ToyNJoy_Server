using Microsoft.EntityFrameworkCore.Storage;
using ToyNJoy.DAL;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.BLL
{
    public class LibraryBLL
    {
        private LibraryDAL libraryDAL;
        private OrderItemDAL orderItemDAL;
        private OrderDAL orderDAL;
        private ShoppingCarDAL shoppingCarDAL;
        private ToyNjoyContext context;

        public LibraryBLL(ToyNjoyContext context)
        {
            this.context = context;
            libraryDAL = new LibraryDAL(context);
            orderItemDAL = new OrderItemDAL(context);
            orderDAL = new OrderDAL(context);
            shoppingCarDAL = new ShoppingCarDAL(context);
        }

        public IEnumerable<Library> find(string? username, double? beginDays, double? endDays, string? orderby)
        {
            return libraryDAL.find(username, beginDays, endDays, orderby);
        }

        public bool add(string orderId, string userName)
        {
            bool result = false;

            Order order = orderDAL.get(orderId);
            order.State = 1;

            IEnumerable<OrderItem> orderItems = orderItemDAL.find(orderId);
            List<Library> libraries = new List<Library>();
            foreach (OrderItem orderItem in orderItems)
            {
                Library library = new Library();
                library.UserName = userName;
                library.ProductId = orderItem.ProductId;
                library.JoinTime = DateTime.Now;
                library.LastTime = DateTime.Now;
                library.TotalHours = 0;
                libraries.Add(library);
            }

            using (IDbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    libraryDAL.add(libraries);
                    orderDAL.upd(order);
                    shoppingCarDAL.del(userName);
                    dbContextTransaction.Commit();

                    result = true;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }
    }
}
