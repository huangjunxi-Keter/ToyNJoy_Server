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

        public bool add(ProductHardwareRequirement productHardwareRequirement)
        {
            context.ProductHardwareRequirements.Add(productHardwareRequirement);
            return context.SaveChanges() > 0;
        }

        public bool upd(ProductHardwareRequirement productHardwareRequirement)
        {
            context.ProductHardwareRequirements.Update(productHardwareRequirement);
            return context.SaveChanges() > 0;
        }
    }
}
