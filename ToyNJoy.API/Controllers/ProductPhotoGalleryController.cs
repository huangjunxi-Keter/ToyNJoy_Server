using Microsoft.AspNetCore.Mvc;
using ToyNJoy.BLL;
using ToyNJoy.Entity.Model;
using ToyNJoy.Entity;

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
    }
}