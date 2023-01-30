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
        /// ����ͼƬ
        /// </summary>
        /// <param name="name">Image·���µ��ļ���</param>
        /// <param name="width">���</param>
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
            if (EmailHelper.SendMail(email, "ע��ToyNJoy", "������֤��Ϊ��" + vc))
                result = vc;
            return result;
        }
    }
}