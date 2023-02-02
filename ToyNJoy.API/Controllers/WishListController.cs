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
        public IEnumerable<WishList> find(string? name, int? maxPrice, int? minPrice, int? typeId, string? orderby) 
        {
            string token = Request.Headers["Authorization"].ToString().Split(' ')[1];
            User loginUser = tokenHelper.GetToken<User>(token);
            return bll.find(loginUser.Username, orderby, name, typeId, minPrice, maxPrice);
        }
    }
}
