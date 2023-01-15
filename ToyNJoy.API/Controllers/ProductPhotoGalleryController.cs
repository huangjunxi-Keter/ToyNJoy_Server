using Microsoft.AspNetCore.Mvc;
using ToyNJoy.BLL;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductPhotoGalleryController : ControllerBase
    {
        private readonly ILogger<ProductPhotoGalleryController> _logger;

        public ProductPhotoGalleryController(ILogger<ProductPhotoGalleryController> logger)
        {
            _logger = logger;
        }

        private ProductPhotoGalleryBLL bll = new ProductPhotoGalleryBLL();

        [HttpGet("getByProductId")]
        public IEnumerable<ProductPhotoGallery> getByProductId(int id)
        {
            return bll.getByProductId(id);
        }
    }
}