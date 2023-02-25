using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToyNJoy.BLL;
using ToyNJoy.Entity.Model;
using ToyNJoy.Entity;
using ToyNJoy.Utiliy;

namespace ToyNJoy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> logger;
        private UserBLL bll;
        private UserInfoBLL infoBll;
        private TokenHelper tokenHelper;

        public UserController(ILogger<UserController> logger, ToyNjoyContext context, TokenHelper tokenHelper)
        {
            this.logger = logger;
            bll = new UserBLL(context);
            infoBll = new UserInfoBLL(context);
            this.tokenHelper = tokenHelper;
        }

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
                var token = tokenHelper.CreateJwtToken(userData);
                Response.Headers["Token"] = token;
                Response.Headers["Access-Control-Expose-Headers"] = "token";
                result = Ok(new ResponseModel { Code = 1, Data = userData });
            }
            return result;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [AllowAnonymous]
        public string add([FromBody]User user)
        {
            return bll.add(user);   
        }

        /// <summary>
        /// 需要token，返回用户头像
        /// </summary>
        /// <returns></returns>
        [HttpGet("userImage")]
        [Authorize]
        public IActionResult GetUserImage()
        {
            User loginUser = BaseUtiliy.getTokenData<User>(Request, tokenHelper);
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
            User loginUser = BaseUtiliy.getTokenData<User>(Request, tokenHelper);
            string imageName = string.Empty;
            if (loginUser != null) 
            {
                imageName = loginUser.VirtualImage;
            }
            return imageName;
        }

        /// <summary>
        /// 获取当前登录的用户【基本信息】
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        [Authorize]
        public User get()
        {
            User loginUser = BaseUtiliy.getTokenData<User>(Request, tokenHelper);
            User result = bll.get(loginUser.Username);
            return result;
        }

        /// <summary>
        /// 获取指定用户的【基本信息】
        /// </summary>
        /// <returns></returns>
        [HttpGet("getByName")]
        [Authorize]
        public User getByName(string Name)
        {
            return bll.get(Name);
        }

        /// <summary>
        /// 获取当前登录的用户【详情】
        /// </summary>
        /// <returns></returns>
        [HttpGet("getInfo")]
        [Authorize]
        public UserInfo getInfo()
        {
            User loginUser = BaseUtiliy.getTokenData<User>(Request, tokenHelper);
            UserInfo result = infoBll.getByName(loginUser.Username);
            return result;
        }

        /// <summary>
        /// 获取指定用户的【详情】
        /// </summary>
        /// <returns></returns>
        [HttpGet("getInfoByName")]
        [Authorize]
        public UserInfo getInfoByName(string Name)
        {
            return infoBll.getByName(Name);
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
            User user = BaseUtiliy.getTokenData<User>(Request, tokenHelper);
            user = bll.get(user.Username);

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

        /// <summary>
        /// 修改用户基本信息
        /// </summary>
        /// <param name="userData">基本信息</param>
        /// <returns></returns>
        [HttpPost("upd")]
        [Authorize]
        public bool upd([FromBody] User userData)
        {
            return bll.upd(userData);
        }

        /// <summary>
        /// 修改用户详情
        /// </summary>
        /// <param name="userInfo">用户详情</param>
        /// <returns></returns>
        [HttpPost("updInfo")]
        [Authorize]
        public bool updInfo([FromBody] UserInfo userInfo)
        {
            return infoBll.upd(userInfo);
        }
    }
}
