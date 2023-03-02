using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToyNJoy.BLL;
using ToyNJoy.Entity.Model;
using ToyNJoy.Entity;

namespace ToyNJoy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserTypeController : Controller
    {
        private readonly ILogger<UserTypeController> logger;
        private UserTypeBLL bll;

        public UserTypeController(ILogger<UserTypeController> logger, ToyNjoyContext context)
        {
            this.logger = logger;
            bll = new UserTypeBLL(context);
        }

        [HttpGet("find")]
        public IEnumerable<UserType> find(string? name, int? state, int? page, int? count)
        {
            return bll.find(name, state, page, count);
        }

        [HttpGet("findCount")]
        public int findCount(string? name, int? state)
        {
            return bll.findCount(name, state);
        }

        [HttpPost("add")]
        [Authorize]
        public bool add([FromBody] UserType UserType)
        {
            return bll.add(UserType);
        }

        [HttpPost("upd")]
        [Authorize]
        public bool upd([FromBody] UserType UserType)
        {
            return bll.upd(UserType);
        }

        [HttpGet("del")]
        [Authorize]
        public bool del(int id)
        {
            return bll.del(id);
        }
    }
}
