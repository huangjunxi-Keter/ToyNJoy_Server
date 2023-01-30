using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToyNJoy.BLL;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        private ProductBLL bll = new ProductBLL();

        [HttpGet("get")]
        public Product getById(int id)
        {
            return bll.getById(id);
        }

        [HttpGet("find")]
        public IEnumerable<Product> find(string? name, int? maxPrice, int? minPrice,
            int? typeId, string? orderby, int? page, int? count)
        {
            return bll.find(name, maxPrice, minPrice, typeId, orderby, page, count);
        }

        [HttpGet("count")]
        public int count(string? name, string? orderby)
        {
            return bll.count(name, orderby);
        }

        [HttpPost("add")]
        public IEnumerable<Product> add([FromBody] Product p)
        {
            return null;
        }
    }
}