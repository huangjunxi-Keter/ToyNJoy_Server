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
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly TokenHelper _tokenHelper;

        public UserController(ILogger<UserController> logger, TokenHelper tokenHelper)
        {
            _logger = logger;
            _tokenHelper = tokenHelper;
        }

        private UserBLL bll = new UserBLL();

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("login")] //不写这个(HttpXXXX) Swagger 会报错
        [AllowAnonymous] //开放接口，不用认证
        public IActionResult Login([FromBody] User user)
        {
            /*
                post 接收不到对象参数，或出现 400、415 错误时：
                    1. 检查 Content-Type 是否兼容
                    2. 字段名是否与一致（有时区分大小写，有时不区分）
                    3. 数据类型（有时要JSON有时要JSON字符串）
                    4. 对象中的未传的属性是否可空（例如：string name 不可空，string? name 可空）
            */

            IActionResult result;
            var userData = bll.Login(user.Username, user.Password);
            if (userData == null)
            {
                result = Ok(new ResponseModel { Code = 0, Message = "账号或密码错误" });
            }
            else
            {
                var token = _tokenHelper.CreateJwtToken(userData);
                Response.Headers["Token"] = token;
                Response.Headers["Access-Control-Expose-Headers"] = "token";
                result = Ok(new ResponseModel { Code = 1, Data = userData });
            }
            return result;
        }

        /// <summary>
        /// 需要token，返回用户头像
        /// </summary>
        /// <returns></returns>
        [HttpGet("userImage")]
        [Authorize]
        public IActionResult GetUserImage()
        {
            string token = Request.Headers["Authorization"].ToString().Split(' ')[1];
            User loginUser = _tokenHelper.GetToken<User>(token);
            string imageName = string.Empty;
            if (loginUser != null) 
            {
                imageName = loginUser.VirtualImage;
            }
            var (fileContentes, contentType) = BaseUtiliy.GetImageInfo(imageName, 0);
            return new FileContentResult(fileContentes, contentType);
        }

        /// <summary>
        /// 需要token，返回用户头像名称
        /// </summary>
        /// <returns></returns>
        [HttpGet("userImageName")]
        [Authorize]
        public string GetUserImageName()
        {
            string token = Request.Headers["Authorization"].ToString().Split(' ')[1];
            User loginUser = _tokenHelper.GetToken<User>(token);
            string imageName = string.Empty;
            if (loginUser != null) 
            {
                imageName = loginUser.VirtualImage;
            }
            return imageName;
        }
    }
}
