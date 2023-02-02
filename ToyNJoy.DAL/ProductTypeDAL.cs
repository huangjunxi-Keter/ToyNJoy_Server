using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.DAL
{
    public class ProductTypeDAL
    {
        private ToyNjoyContext context;

        public ProductTypeDAL(ToyNjoyContext context)
        {
            this.context = context;
        }

        public IEnumerable<ProductType> find() 
        {
            return context.ProductTypes;
        }
    }
}
