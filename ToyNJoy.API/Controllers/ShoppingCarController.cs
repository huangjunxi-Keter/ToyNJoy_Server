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
    public class ShoppingCarController : Controller
    {
        private readonly ILogger<ShoppingCarController> logger;
        private ShoppingCarBLL bll;
        private TokenHelper tokenHelper;

        public ShoppingCarController(ILogger<ShoppingCarController> logger, ToyNjoyContext context, TokenHelper tokenHelper)
        {
            this.logger = logger;
            bll = new ShoppingCarBLL(context);
            this.tokenHelper = tokenHelper;
        }

        [HttpGet("find")]
        [Authorize]
        public IEnumerable<ShoppingCar> find(double? beginDays, double? endDays) 
        {
            string token = Request.Headers["Authorization"].ToString().Split(' ')[1];
            User loginUser = tokenHelper.GetToken<User>(token);
            return bll.find(loginUser.Username);
        }
    }
}
