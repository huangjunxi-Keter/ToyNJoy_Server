using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToyNJoy.Utiliy;

namespace ToyNJoy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemController : ControllerBase
    {
        private readonly ILogger<SystemController> logger;

        public SystemController(ILogger<SystemController> logger)
        {
            this.logger = logger;
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
        public string EmailValidation(string email, string? title)
        {
            string result = "";
            string vc = BaseUtiliy.GenerateVerificationCode();
            if (EmailHelper.SendMail(email, !string.IsNullOrEmpty(title) ? title : "ע��ToyNJoy", "������֤��Ϊ��" + vc))
                result = vc;
            return result;
        }

        [HttpGet("sendEmail")]
        public bool SendEmail(string email, string title, string message)
        {
            return EmailHelper.SendMail(email, title, message);
        }

        [HttpGet("deleteFile")]
        [Authorize]
        public void deleteFile(string path, string fileName)
        {
            BaseUtiliy.DeleteFile(path, fileName);
        }
    }
}