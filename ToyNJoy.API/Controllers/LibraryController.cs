using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToyNJoy.BLL;
using ToyNJoy.Entity.Model;
using ToyNJoy.Utiliy;

namespace ToyNJoy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : Controller
    {
        private readonly ILogger<LibraryController> _logger;
        private readonly TokenHelper _tokenHelper;

        public LibraryController(ILogger<LibraryController> logger, TokenHelper tokenHelper)
        {
            _logger = logger;
            _tokenHelper = tokenHelper;
        }

        private LibraryBLL bll = new LibraryBLL();

        [HttpGet("find")]
        [Authorize]
        public IEnumerable<Library> find(double? beginDays, double? endDays) 
        {
            string token = Request.Headers["Authorization"].ToString().Split(' ')[1];
            User loginUser = _tokenHelper.GetToken<User>(token);
            return bll.find(loginUser.Username, beginDays, endDays);
        }
    }
}
