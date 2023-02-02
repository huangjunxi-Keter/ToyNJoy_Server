using Microsoft.AspNetCore.Mvc;
using ToyNJoy.BLL;
using ToyNJoy.Entity.Model;
using ToyNJoy.Entity;

namespace ToyNJoy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductHardwareRequirementController : ControllerBase
    {
        private readonly ILogger<ProductHardwareRequirementController> logger;
        private ProductHardwareRequirementBLL bll;

        public ProductHardwareRequirementController(ILogger<ProductHardwareRequirementController> logger, ToyNjoyContext context)
        {
            this.logger = logger;
            bll = new ProductHardwareRequirementBLL(context);
        }

        [HttpGet("getByProductId")]
        public ProductHardwareRequirement getByProductId(int id)
        {
            return bll.getByProductId(id);
        }
    }
}