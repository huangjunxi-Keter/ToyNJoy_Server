using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToyNJoy.BLL;
using ToyNJoy.Entity.Model;
using ToyNJoy.Utiliy;

namespace ToyNJoy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCarController : Controller
    {
        private readonly ILogger<ShoppingCarController> _logger;
        private readonly TokenHelper _tokenHelper;

        public ShoppingCarController(ILogger<ShoppingCarController> logger, TokenHelper tokenHelper)
        {
            _logger = logger;
            _tokenHelper = tokenHelper;
        }

        private ShoppingCarBLL bll = new ShoppingCarBLL();

        [HttpGet("find")]
        [Authorize]
        public IEnumerable<ShoppingCar> find(double? beginDays, double? endDays) 
        {
            string token = Request.Headers["Authorization"].ToString().Split(' ')[1];
            User loginUser = _tokenHelper.GetToken<User>(token);
            return bll.find(loginUser.Username);
        }
    }
}
