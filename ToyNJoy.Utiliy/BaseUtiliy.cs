using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.Utiliy
{
    public static class BaseUtiliy
    {
        public static object GetPropertyValue(object obj, string property)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(property);
            return propertyInfo.GetValue(obj, null);
        }

        public static (byte[] fileContents, string contentType) GetImageInfo(string? name, int width = 0)
        {
            byte[] fileContents;
            string contentType;

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
            contentType = "image/jpeg";

            var imgTypeSplit = imgPath.Split('.');
            var imgType = imgTypeSplit[imgTypeSplit.Length - 1].ToLower();

            // 未知的图片类型
            if (!contentTypeDict.ContainsKey(imgType))
                imgPath = errorImage;
            else
                contentType = contentTypeDict[imgType];

            // 图片不存在
            if (!new FileInfo(imgPath).Exists)
                imgPath = errorImage;

            // 原图
            if (width <= 0)
            {
                try
                {
                    using (var sw = new FileStream(imgPath, FileMode.Open))
                    {
                        var bytes = new byte[sw.Length];
                        sw.Read(bytes, 0, bytes.Length);
                        sw.Close();

                        fileContents = bytes;
                    }
                }
                catch(IOException e) 
                {
                    Console.WriteLine(e.ToString());
                    return (new byte[0], contentType);
                }
            }
            else
            {
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
                    newImage.Save(ms, ImageFormat.Bmp);
                    var bytes = ms.GetBuffer();
                    ms.Close();

                    fileContents = bytes;
                }
            }

            return (fileContents, contentType);
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        public static string GenerateVerificationCode()
        {
            string VerificationCode = "";
            char[] chars = {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K',
            'L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
            Random rd = new Random();
            for (int i = 0; i < 5; i++)
            {
                VerificationCode += chars[rd.Next(0, chars.Length)];
            }
            return VerificationCode;
        }

        public static string GenerateOrderId() 
        {
            Random rd = new Random();
            string result = "";
            result += DateTime.Now.ToString("yyyyMMddHHmm");
            result += rd.Next(10, 99).ToString();
            result += DateTime.Now.ToString("mm");
            result += rd.Next(100, 999).ToString();
            return result;
        }

        public static T getTokenData<T>(HttpRequest request, TokenHelper tokenHelper)
        {
            string token = request.Headers["Authorization"].ToString().Split(' ')[1];
            T data = tokenHelper.GetToken<T>(token);
            return data;
        }

        public static string SaveFile(string baseName, string path, IFormFile file)
        {
            string fileType = file.FileName.Substring(file.FileName.LastIndexOf('.'));
            string fileName = baseName;
            // 组成新名字
            if (fileName.IndexOf(".") == -1)
            {
                fileName += DateTime.Now.ToString("yyyyMMddhhmmms") + fileType;
            }
            string filename = AppContext.BaseDirectory.Split("\\bin\\")[0] + path + "/" + fileName;
            DeleteFile(path, fileName);
            using (FileStream fs = System.IO.File.Create(filename))
            {
                // 复制文件
                file.CopyTo(fs);
                // 清空缓冲区数据
                fs.Flush();
            }

            return fileName;
        }

        public static void DeleteFile(string path, string fileName)
        { 
            string filepath = AppContext.BaseDirectory.Split("\\bin\\")[0] + path + "/" + fileName;
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }
        }

        private static string GenerateStringID()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

        private static long GenerateIntIDInt64()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }
    }
}