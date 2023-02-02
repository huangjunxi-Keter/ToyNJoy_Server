using Microsoft.AspNetCore.Mvc;
using ToyNJoy.BLL;
using ToyNJoy.Entity.Model;
using ToyNJoy.Entity;

namespace ToyNJoy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductTypeController : Controller
    {
        private readonly ILogger<ProductTypeController> logger;
        private ProductTypeBLL bll;

        public ProductTypeController(ILogger<ProductTypeController> logger, ToyNjoyContext context)
        {
            this.logger = logger;
            bll = new ProductTypeBLL(context);
        }

        [HttpGet("find")]
        public IEnumerable<ProductType> find() 
        {
            return bll.find();
        }
    }
}
