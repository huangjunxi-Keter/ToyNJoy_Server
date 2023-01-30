using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;
using ToyNJoy.Utiliy;

namespace ToyNJoy.DAL
{
    public class ProductTypeDAL
    {
        private ToyNjoyContext db = new ToyNjoyContext();

        public IEnumerable<ProductType> find() 
        {
            return db.ProductTypes;
        }
    }
}
