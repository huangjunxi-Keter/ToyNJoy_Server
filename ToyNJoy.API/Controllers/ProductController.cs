using Microsoft.AspNetCore.Mvc;
using ToyNJoy.BLL;
using ToyNJoy.Entity.Model;
using ToyNJoy.Entity;

namespace ToyNJoy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private ProductBLL bll;

        public ProductController(ILogger<ProductController> logger, ToyNjoyContext context)
        {
            this.logger = logger;
            bll = new ProductBLL(context);
        }

        [HttpGet("get")]
        public Product getById(int id)
        {
            return bll.getById(id);
        }

        [HttpGet("find")]
        public IEnumerable<Product> find(string? name, int? maxPrice, int? minPrice,
            int? typeId, string? orderby, int? page, int? count)
        {
            var data = bll.find(name, maxPrice, minPrice, typeId, orderby, page, count);
            return data;
        }

        [HttpGet("count")]
        public int count(string? name, string? orderby)
        {
            return bll.count(name, orderby);
        }

        [HttpPost("add")]
        public bool add([FromBody] Product p)
        {
            return bll.add(p);
        }
    }
}