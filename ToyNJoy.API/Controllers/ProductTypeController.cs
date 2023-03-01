using Microsoft.AspNetCore.Authorization;
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
        public IEnumerable<ProductType> find(string? name, int? state, int? page, int? count)
        {
            return bll.find(name, state, page, count);
        }

        [HttpGet("findCount")]
        public int findCount(string? name, int? state)
        {
            return bll.findCount(name, state);
        }

        [HttpPost("add")]
        [Authorize]
        public bool add([FromBody] ProductType productType)
        {
            return bll.add(productType);
        }

        [HttpPost("upd")]
        [Authorize]
        public bool upd([FromBody] ProductType productType)
        {
            return bll.upd(productType);
        }

        [HttpGet("del")]
        [Authorize]
        public bool del(int id)
        {
            return bll.del(id);
        }
    }
}
