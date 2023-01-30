using Microsoft.AspNetCore.Mvc;
using ToyNJoy.Utiliy;

namespace ToyNJoy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemController : ControllerBase
    {
        private readonly ILogger<SystemController> _logger;

        public SystemController(ILogger<SystemController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 请求图片
        /// </summary>
        /// <param name="name">Image路径下的文件名</param>
        /// <param name="width">宽度</param>
        /// <returns></returns>
        [HttpGet("file/image")]
        public IActionResult GetImage(string? name, int width = 0)
        {
            var (fileContentes, contentType) = BaseUtiliy.GetImageInfo(name, width);
            FileContentResult result = new FileContentResult(fileContentes, contentType);
            return result;
        }

        [HttpGet("getVerificationCode")]
        public string EmailValidation(string email)
        {
            string result = "";
            string vc = BaseUtiliy.GenerateVerificationCode();
            if (EmailHelper.SendMail(email, "注册ToyNJoy", "您的验证码为：" + vc))
                result = vc;
            return result;
        }
    }
}