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
            int? typeId, int? state, string? orderby, int? page, int? count)
        {
            var data = bll.find(name, maxPrice, minPrice, typeId, state, orderby, page, count);
            return data;
        }

        [HttpGet("findCount")]
        public int findCount(string? name, int? maxPrice, int? minPrice, int? typeId, int? state)
        {
            return bll.findCount(name, maxPrice, minPrice, typeId, state);
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
        public bool updateImage([FromForm] IFormCollection keyValuePairs)
        {
            bool result = false;
            try
            {
                FormFileCollection formFiles = (FormFileCollection)keyValuePairs.Files;
                foreach (FormFile file in formFiles)
                {
                    Product product = bll.getById(Convert.ToInt32(file.Name));
                    string oldImage = product.Image;
                    product.Image = BaseUtiliy.SaveFile(file.Name, "/Image/products", file);
                    if (bll.upd(product))
                    {
                        if (oldImage != ".png")
                        {
                            BaseUtiliy.DeleteFile("/Image/products", oldImage);
                        }
                        result = true;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        [HttpPost("updateFile")]
        [Authorize]
        public string upload([FromForm] IFormCollection keyValuePairs)
        {
            string result = "";
            try
            {
                FormFileCollection formFiles = (FormFileCollection)keyValuePairs.Files;
                foreach (FormFile file in formFiles)
                {
                    Product product = bll.getById(Convert.ToInt32(file.Name));
                    string oldFileName = product.FileName;
                    product.FileName = BaseUtiliy.SaveFile(file.Name, "/Games", file);
                    if (bll.upd(product))
                    {
                        if (!string.IsNullOrEmpty(oldFileName))
                        {
                            BaseUtiliy.DeleteFile("/Games", oldFileName);
                        }
                        result = product.FileName;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
    }
}