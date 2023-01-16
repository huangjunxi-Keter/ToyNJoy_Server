using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.DAL
{
    public class ProductHardwareRequirementDAL
    {
        private ToyNjoyContext db = new ToyNjoyContext();

        public ProductHardwareRequirement getByProductId(int id) 
        {
            return db.ProductHardwareRequirements.First(p => p.ProductId == id);
        }
    }
}
