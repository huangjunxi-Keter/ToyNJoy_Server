using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToyNJoy.BLL;
using ToyNJoy.Entity.Model;
using ToyNJoy.Utiliy;

namespace ToyNJoy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WishListController : Controller
    {
        private readonly ILogger<WishListController> _logger;
        private readonly TokenHelper _tokenHelper;

        public WishListController(ILogger<WishListController> logger, TokenHelper tokenHelper)
        {
            _logger = logger;
            _tokenHelper = tokenHelper;
        }

        private WishListBLL bll = new WishListBLL();

        [HttpGet("find")]
        [Authorize]
        public IEnumerable<WishList> find(string? name, int? maxPrice, int? minPrice, int? typeId, string? orderby) 
        {
            string token = Request.Headers["Authorization"].ToString().Split(' ')[1];
            User loginUser = _tokenHelper.GetToken<User>(token);
            return bll.find(loginUser.Username, orderby, name, typeId, minPrice, maxPrice);
        }
    }
}
