using Microsoft.AspNetCore.Mvc;
using ToyNJoy.BLL;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductHardwareRequirementController : ControllerBase
    {
        private readonly ILogger<ProductHardwareRequirementController> _logger;

        public ProductHardwareRequirementController(ILogger<ProductHardwareRequirementController> logger)
        {
            _logger = logger;
        }

        private ProductHardwareRequirementBLL bll = new ProductHardwareRequirementBLL();

        [HttpGet("getByProductId")]
        public ProductHardwareRequirement getByProductId(int id)
        {
            return bll.getByProductId(id);
        }
    }
}