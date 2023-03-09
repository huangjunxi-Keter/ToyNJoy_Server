using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
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
        private WishListDAL wishListDAL;
        private ProductDAL productDAL;
        private ToyNjoyContext context;

        public LibraryBLL(ToyNjoyContext context)
        {
            this.context = context;
            libraryDAL = new LibraryDAL(context);
            orderItemDAL = new OrderItemDAL(context);
            orderDAL = new OrderDAL(context);
            productDAL = new ProductDAL(context);
            wishListDAL = new WishListDAL(context);
        }

        public IEnumerable<Library> find(string? userName, string productName, int? productId, int? productTypeId, 
            double? beginDays, double? endDays, string? orderby, int? page, int? count)
        {
            return libraryDAL.find(userName, productName, productId, productTypeId, beginDays, endDays, orderby, page, count);
        }

        public int findCount(string? userName, string productName, int? productId, int? productTypeId,
            double? beginDays, double? endDays)
        {
            return libraryDAL.findCount(userName, productName, productId, productTypeId, beginDays, endDays);
        }

        public bool add(Alipay alipay, string userName)
        {
            bool result = false;

            Order order = orderDAL.get(alipay.out_trade_no);
            order.State = 1;
            order.AlipayResponse = JsonConvert.SerializeObject(alipay);

            IEnumerable<OrderItem> orderItems = orderItemDAL.find(alipay.out_trade_no);
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
                    wishListDAL.del(userName, orderItems);
                    foreach (OrderItem item in orderItems)
                    {
                        Product product = productDAL.getById(item.ProductId);
                        product.Purchases += 1;
                        productDAL.upd(product);
                    }
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
