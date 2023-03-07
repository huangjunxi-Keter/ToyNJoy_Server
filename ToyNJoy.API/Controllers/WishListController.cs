using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToyNJoy.BLL;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;
using ToyNJoy.Utiliy;

namespace ToyNJoy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WishListController : Controller
    {
        private readonly ILogger<WishListController> logger;
        private WishListBLL bll;
        private readonly TokenHelper tokenHelper;

        public WishListController(ILogger<WishListController> logger, ToyNjoyContext context, TokenHelper tokenHelper)
        {
            this.logger = logger;
            bll = new WishListBLL(context);
            this.tokenHelper = tokenHelper;
        }

        [HttpGet("find")]
        [Authorize]
        public IEnumerable<WishList> find(string? name, int? maxPrice, int? minPrice, int? productId, int? typeId, string? orderby) 
        {
            User loginUser = BaseUtiliy.getTokenData<User>(Request, tokenHelper);
            return bll.find(loginUser.Username, orderby, name, productId, typeId, minPrice, maxPrice);
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
