using ToyNJoy.DAL;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.BLL
{
    public class ProductBLL
    {
        private ProductDAL productDAL;
        private ToyNjoyContext context;

        public ProductBLL(ToyNjoyContext context)
        {
            this.context = context;
            productDAL = new ProductDAL(context);
        }

        public bool add(Product p)
        {
            p.Discount = 1;
            return productDAL.add(p);
        }

        public bool del(String id)
        {
            return productDAL.del(id);
        }

        public bool upd(Product p)
        {
            return productDAL.upd(p);
        }

        public Product getById(int id)
        {
            return productDAL.getById(id);
        }

        public IEnumerable<Product> find(string? name, int? maxPrice, int? minPrice,
            int? typeId, string? orderby, int? page, int? count)
        {
            return productDAL.find(name, maxPrice, minPrice, typeId, orderby, page, count);
        }

        public int count(string? name, int? maxPrice, int? minPrice, int? typeId)
        {
            return productDAL.count(name, maxPrice, minPrice, typeId);
        }
    }
}
