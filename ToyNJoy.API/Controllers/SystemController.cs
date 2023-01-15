using Microsoft.AspNetCore.Mvc;
using System.Drawing;

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
            FileContentResult result;
            // AppContext.BaseDirectory = "E:\\MyProject\\Visual_Studio\\ToyNJoy_Server\\ToyNJoy.API\\bin\\Debug\\net6.0\\"
            var appPath = AppContext.BaseDirectory.Split("\\bin\\")[0] + "/Image/";
            var errorImage = appPath + "system/404.png";
            var imgPath = string.IsNullOrEmpty(name) ? errorImage : appPath + name;
            //获取图片的返回类型
            var contentTypeDict = new Dictionary<string, string> {
                {"jpg","image/jpeg"},
                {"jpeg","image/jpeg"},
                {"jpe","image/jpeg"},
                {"png","image/png"},
                {"gif","image/gif"},
                {"ico","image/x-ico"},
                {"tif","image/tiff"},
                {"tiff","image/tiff"},
                {"fax","image/fax"},
                {"wbmp","image//vnd.wap.wbmp"},
                {"rp","image/vnd.rn-realpix"}
            };
            var contentTypeStr = "image/jpeg";
            var imgTypeSplit = imgPath.Split('.');
            var imgType = imgTypeSplit[imgTypeSplit.Length - 1].ToLower();
            // 未知的图片类型
            if (!contentTypeDict.ContainsKey(imgType))
                imgPath = errorImage;
            else
                contentTypeStr = contentTypeDict[imgType];
            // 图片不存在
            if (!new FileInfo(imgPath).Exists)
                imgPath = errorImage;
            // 原图
            if (width <= 0)
            {
                using (var sw = new FileStream(imgPath, FileMode.Open))
                {
                    var bytes = new byte[sw.Length];
                    sw.Read(bytes, 0, bytes.Length);
                    sw.Close();
                    result = new FileContentResult(bytes, contentTypeStr);
                }
            }
            else {
                // 缩小图片
                using (var imgBmp = new Bitmap(imgPath))
                {
                    // 找到新尺寸
                    var oldWidth = imgBmp.Width;
                    var oldHeight = imgBmp.Height;
                    var height = oldHeight;
                    if (width > oldHeight)
                        width = oldHeight;
                    else
                        height = width * oldHeight / oldWidth;

                    var newImage = new Bitmap(imgBmp, width, height);
                    newImage.SetResolution(72, 72);
                    var ms = new MemoryStream();
                    newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    var bytes = ms.GetBuffer();
                    ms.Close();
                    result = new FileContentResult(bytes, contentTypeStr);
                }
            }
            return result;
        }


    }
}