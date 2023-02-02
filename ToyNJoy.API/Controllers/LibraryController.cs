using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;
using ToyNJoy.BLL;
using ToyNJoy.Utiliy;

namespace ToyNJoy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : Controller
    {
        private readonly ILogger<LibraryController> logger;
        private LibraryBLL bll;
        private TokenHelper tokenHelper;

        public LibraryController(ILogger<LibraryController> logger, ToyNjoyContext contex, TokenHelper tokenHelper)
        {
            this.logger = logger;
            bll = new LibraryBLL(contex);
            this.tokenHelper = tokenHelper;
        }

        [HttpGet("find")]
        [Authorize]
        public IEnumerable<Library> find(double? beginDays, double? endDays, string? orderby) 
        {
            string token = Request.Headers["Authorization"].ToString().Split(' ')[1];
            User loginUser = tokenHelper.GetToken<User>(token);
            return bll.find(loginUser.Username, beginDays, endDays, orderby);
        }

        [HttpGet("post")]
        [Authorize]
        public bool add([FromBody] Order order)
        {
            string token = Request.Headers["Authorization"].ToString().Split(' ')[1];
            User loginUser = tokenHelper.GetToken<User>(token);

            return bll.add(order.Id, loginUser.Username);
        }
    }
}
