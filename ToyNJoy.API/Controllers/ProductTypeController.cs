using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToyNJoy.BLL;
using ToyNJoy.Entity.Model;
using ToyNJoy.Utiliy;

namespace ToyNJoy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductTypeController : Controller
    {
        private readonly ILogger<ProductTypeController> _logger;
        private readonly TokenHelper _tokenHelper;

        public ProductTypeController(ILogger<ProductTypeController> logger, TokenHelper tokenHelper)
        {
            _logger = logger;
            _tokenHelper = tokenHelper;
        }

        private ProductTypeBLL bll = new ProductTypeBLL();

        [HttpGet("find")]
        public IEnumerable<ProductType> find() 
        {
            return bll.find();
        }
    }
}
