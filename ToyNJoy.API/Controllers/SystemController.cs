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
        public string EmailValidation(string email, string? title)
        {
            string result = "";
            string vc = BaseUtiliy.GenerateVerificationCode();
            if (EmailHelper.SendMail(email, !string.IsNullOrEmpty(title) ? title : "注册ToyNJoy", "您的验证码为：" + vc))
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

        [HttpGet("download")]
        [Authorize]
        public IActionResult download(string path, string fileName)
        {
            try
            {
                //文件物理路径
                string filePath = AppContext.BaseDirectory.Split("\\bin\\")[0] + path + "/" + fileName;
                if (!System.IO.File.Exists(filePath))
                {
                    return new EmptyResult();
                }
                //异步读取文件
                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite, 4096, true);
                //为true时，支持断点续传
                return File(fileStream, "application/octet-stream", fileName, true);
            }
            catch (Exception ex)
            {
                return new EmptyResult();
            }
        }
    }
}