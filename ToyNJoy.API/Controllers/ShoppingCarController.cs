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
        public IEnumerable<ShoppingCar> find(int? productId) 
        {
            User loginUser = BaseUtiliy.getTokenData<User>(Request, tokenHelper);
            return bll.find(loginUser.Username, productId);
        }

        [HttpGet("add")]
        [Authorize]
        public bool add(int productId)
        {
            User loginUser = BaseUtiliy.getTokenData<User>(Request, tokenHelper);
            return bll.add(loginUser.Username, productId);
        }

        [HttpGet("del")]
        [Authorize]
        public bool del(int id)
        {
            return bll.del(id);
        }
    }
}
