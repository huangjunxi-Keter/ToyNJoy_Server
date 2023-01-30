using ToyNJoy.Entity.Model;
using ToyNJoy.DAL;

namespace ToyNJoy.BLL
{
    public class ProductTypeBLL
    {
        private ProductTypeDAL dal = new ProductTypeDAL();

        public IEnumerable<ProductType> find()
        {
            return dal.find();
        }
    }
}
