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

        public IEnumerable<ProductType> find()
        {
            return productTypeDAL.find();
        }
    }
}
