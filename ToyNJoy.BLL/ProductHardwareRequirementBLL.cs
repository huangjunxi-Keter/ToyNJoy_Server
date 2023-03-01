using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;
using ToyNJoy.DAL;

namespace ToyNJoy.BLL
{
    public class ProductHardwareRequirementBLL
    {
        private ProductHardwareRequirementDAL productHardwareRequirementDAL;
        private ToyNjoyContext context;

        public ProductHardwareRequirementBLL(ToyNjoyContext context)
        {
            this.context = context;
            productHardwareRequirementDAL = new ProductHardwareRequirementDAL(context);
        }

        public ProductHardwareRequirement getByProductId(int id)
        { 
            return productHardwareRequirementDAL.getByProductId(id);
        }

        public bool upd(ProductHardwareRequirement productHardwareRequirement)
        {
            return productHardwareRequirementDAL.upd(productHardwareRequirement);
        }
    }
}
