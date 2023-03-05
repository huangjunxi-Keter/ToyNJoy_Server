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
    public class ProductPhotoGalleryController : ControllerBase
    {
        private readonly ILogger<ProductPhotoGalleryController> logger;
        private ProductPhotoGalleryBLL bll;

        public ProductPhotoGalleryController(ILogger<ProductPhotoGalleryController> logger, ToyNjoyContext context)
        {
            this.logger = logger;
            bll = new ProductPhotoGalleryBLL(context);
        }

        [HttpGet("getByProductId")]
        public IEnumerable<ProductPhotoGallery> getByProductId(int id)
        {
            return bll.getByProductId(id);
        }

        [HttpPost("add")]
        [Authorize]
        public string add([FromForm] IFormCollection keyValuePairs)
        {
            string result = "";
            FormFileCollection formFiles = (FormFileCollection)keyValuePairs.Files;
            foreach (FormFile file in formFiles)
            {
                string image = BaseUtiliy.SaveFile(file.Name, "/Image/photoGallery", file);
                if (bll.add(Convert.ToInt32(file.Name), image))
                {
                    result = image;
                }
            }

            return result;
        }

        [HttpGet("del")]
        [Authorize]
        public bool del(int productId, string image)
        {
            bool result = false;
            if (bll.del(productId, image))
            {
                BaseUtiliy.DeleteFile("/Image/photoGallery", image);
                result = true;
            }
            return result;
        }
    }
}