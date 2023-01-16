using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;
using ToyNJoy.DAL;

namespace ToyNJoy.BLL
{
    public class ProductHardwareRequirementBLL
    {
        private ProductHardwareRequirementDAL dal = new ProductHardwareRequirementDAL();

        public ProductHardwareRequirement getByProductId(int id)
        { 
            return dal.getByProductId(id);
        }
    }
}
