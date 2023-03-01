using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToyNJoy.BLL;
using ToyNJoy.Entity.Model;
using ToyNJoy.Entity;
using ToyNJoy.Utiliy;

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

        [HttpGet("findCount")]
        public int findCount(string? name, int? maxPrice, int? minPrice, int? typeId)
        {
            return bll.findCount(name, maxPrice, minPrice, typeId);
        }

        [HttpPost("add")]
        [Authorize]
        public Product add([FromBody] Product p)
        {
            return bll.add(p);
        }

        [HttpPost("upd")]
        [Authorize]
        public bool upd([FromBody] Product p)
        {
            return bll.upd(p);
        }

        [HttpPost("updateImage")]
        [Authorize]
        public string updateImage([FromForm] IFormCollection keyValuePairs)
        {
            string result = "";
            FormFileCollection formFiles = (FormFileCollection)keyValuePairs.Files;
            foreach (FormFile file in formFiles)
            {
                Product product = bll.getById(Convert.ToInt32(file.Name));
                string oldImage = product.Image;
                product.Image = BaseUtiliy.SaveImage(file.Name, "products", file);
                if (bll.upd(product))
                {
                    if (oldImage != ".png") 
                    {
                        BaseUtiliy.DeleteImage("products", oldImage);
                    }
                    result = product.Image;
                }
            }
            return result;
        }
    }
}