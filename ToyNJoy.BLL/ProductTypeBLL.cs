using ToyNJoy.Entity.Model;
using ToyNJoy.DAL;
using ToyNJoy.Entity;

namespace ToyNJoy.BLL
{
    public class ProductTypeBLL
    {
        private ProductTypeDAL productTypeDAL;
        private ToyNjoyContext context;

        public ProductTypeBLL(ToyNjoyContext context)
        {
            this.context = context;
            productTypeDAL = new ProductTypeDAL(context);
        }

        public IEnumerable<ProductType> find(string name, int? state, int? page, int? count)
        {
            return productTypeDAL.find(name, state, page, count);
        }

        public int findCount(string name, int? state)
        {
            return productTypeDAL.findCount(name, state);
        }

        public bool add(ProductType productType)
        {
            return productTypeDAL.add(productType);
        }

        public bool upd(ProductType productType)
        {
            return productTypeDAL.upd(productType);
        }

        public bool del(int id)
        {
            return productTypeDAL.del(id);
        }
    }
}
