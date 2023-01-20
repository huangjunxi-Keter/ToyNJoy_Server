using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToyNJoy.BLL;
using ToyNJoy.Entity.Model;
using ToyNJoy.Utiliy;

namespace ToyNJoy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserInfoController : Controller
    {
        private readonly ILogger<UserInfoController> _logger;
        private readonly TokenHelper _tokenHelper;

        public UserInfoController(ILogger<UserInfoController> logger, TokenHelper tokenHelper)
        {
            _logger = logger;
            _tokenHelper = tokenHelper;
        }

        private UserInfoBLL bll = new UserInfoBLL();

        /// <summary>
        /// 获取当前登录的用户详情
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        [Authorize]
        public UserInfo get()
        {
            string token = Request.Headers["Authorization"].ToString().Split(' ')[1];
            User user = _tokenHelper.GetToken<User>(token);
            UserInfo result = bll.getByName(user.Username);
            return result;
        }

        /// <summary>
        /// 获取用户详情
        /// </summary>
        /// <returns></returns>
        [HttpGet("getByName")]
        [Authorize]
        public UserInfo getByName(string Name)
        {
            return bll.getByName(Name);
        }
    }
}
