using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.DAL
{
    public class ProductHardwareRequirementDAL
    {
        private ToyNjoyContext context;

        public ProductHardwareRequirementDAL(ToyNjoyContext context)
        {
            this.context = context;
        }

        public ProductHardwareRequirement getByProductId(int id) 
        {
            return context.ProductHardwareRequirements.First(p => p.ProductId == id);
        }
    }
}
