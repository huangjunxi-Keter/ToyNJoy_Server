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

        /// <summary>
        /// 获取当前登录的用户详情
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        [Authorize]
        public User get()
        {
            string token = Request.Headers["Authorization"].ToString().Split(' ')[1];
            User user = _tokenHelper.GetToken<User>(token);
            User result = bll.getByName(user.Username);
            return result;
        }

        /// <summary>
        /// 获取用户详情
        /// </summary>
        /// <returns></returns>
        [HttpGet("getByName")]
        [Authorize]
        public User getByName(string Name)
        {
            return bll.getByName(Name);
        }


        /// <summary>
        /// 更新头像
        /// </summary>
        /// <param name="virtualImage">FromData</param>
        /// <returns></returns>
        [HttpPost("updateVirtual")]
        [Authorize]
        public bool updateVirtual([FromForm] IFormCollection virtualImage)
        {
            string token = Request.Headers["Authorization"].ToString().Split(' ')[1];
            User user = _tokenHelper.GetToken<User>(token);
            user = bll.getByName(user.Username);

            FormFileCollection fileCollection = (FormFileCollection)virtualImage.Files;
            foreach (IFormFile file in fileCollection)
            {
                // 组成新名字
                string imageType = file.FileName.Substring(file.FileName.LastIndexOf('.'));
                string imageName = user.Username + "_virtual" + imageType;

                string filename = AppContext.BaseDirectory.Split("\\bin\\")[0] + "/Image/user/" + imageName;
                if (System.IO.File.Exists(filename))
                {
                    System.IO.File.Delete(filename);
                }
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    // 复制文件
                    file.CopyTo(fs);
                    // 清空缓冲区数据
                    fs.Flush();
                }
                user.VirtualImage = imageName;
            }

            return bll.upd(user);
        }
    }
}
