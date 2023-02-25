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
    public class AdministratorController : Controller
    {
        private readonly ILogger<AdministratorController> logger;
        private AdministratorBLL bll;
        private TokenHelper tokenHelper;

        public AdministratorController(ILogger<AdministratorController> logger, ToyNjoyContext context, TokenHelper tokenHelper)
        {
            this.logger = logger;
            bll = new AdministratorBLL(context);
            this.tokenHelper = tokenHelper;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="Administrator"></param>
        /// <returns></returns>
        [HttpPost("login")] //不写这个(HttpXXXX) Swagger 会报错
        [AllowAnonymous] //开放接口，不用认证
        public IActionResult Login([FromBody] Administrator Administrator)
        {
            /*
                post 接收不到对象参数，或出现 400、415 错误时：
                    1. 检查 Content-Type 是否兼容
                    2. 字段名是否与一致（有时区分大小写，有时不区分）
                    3. 数据类型（有时要JSON有时要JSON字符串）
                    4. 对象中的未传的属性是否可空（例如：string name 不可空，string? name 可空）
            */

            IActionResult result;
            var AdministratorData = bll.Login(Administrator);
            if (AdministratorData == null)
            {
                result = Ok(new ResponseModel { Code = 0, Message = "账号或密码错误" });
            }
            else
            {
                var token = tokenHelper.CreateJwtToken(AdministratorData);
                Response.Headers["Token"] = token;
                Response.Headers["Access-Control-Expose-Headers"] = "token";
                result = Ok(new ResponseModel { Code = 1, Data = AdministratorData });
            }
            return result;
        }

        [HttpGet("get")]
        [Authorize]
        public Administrator get() 
        {
            Administrator administrator = BaseUtiliy.getTokenData<Administrator>(Request, tokenHelper);
            Administrator result = bll.get(administrator.Id);
            return result;
        }
    }
}
