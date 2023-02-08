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
        public IEnumerable<Library> find(string? name, int? productId, int? typeId, double? beginDays, double? endDays, string? orderby) 
        {
            User loginUser = BaseUtiliy.getLoginUser(Request, tokenHelper);
            return bll.find(loginUser.Username, name, productId, typeId, beginDays, endDays, orderby);
        }

        [HttpPost("add")]
        [Authorize]
        public bool add([FromBody] Alipay alipay)
        {
            User loginUser = BaseUtiliy.getLoginUser(Request, tokenHelper);
            return bll.add(alipay, loginUser.Username);
        }
    }
}
