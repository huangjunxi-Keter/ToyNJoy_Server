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
    public class NewsController : Controller
    {
        private readonly ILogger<NewsController> logger;
        private NewsBLL bll;

        public NewsController(ILogger<NewsController> logger, ToyNjoyContext context)
        {
            this.logger = logger;
            bll = new NewsBLL(context);
        }
        /// <summary>
        /// 查询新闻
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="text">内容</param>
        /// <param name="date">更新日期</param>
        /// <param name="productId">产品id</param>
        /// <param name="typeId">类型id</param>
        /// <param name="orderby">排序方式</param>
        /// <param name="page">当前页减一</param>
        /// <param name="count">总条数</param>
        /// <returns></returns>

        [HttpGet("find")]
        public IEnumerable<News> find(string? title, string? text, DateTime? date, int? productId, int? typeId, string? orderby, int? page, int? count)
        {
            return bll.find(title, text, date, productId, typeId, orderby, page, count);
        }

        /// <summary>
        /// 查询新闻总数
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="text">内容</param>
        /// <param name="productId">产品id</param>
        /// <param name="typeId">类型id</param>
        /// <returns></returns>

        [HttpGet("findCount")]
        public int findCount(string? title, string? text, DateTime? date, int? productId, int? typeId)
        {
            return bll.findCount(title, text, date, productId, typeId);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("get")]
        public News get(int id)
        {
            return bll.get(id);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="news">新闻实体</param>
        /// <returns></returns>
        [HttpPost("add")]
        [Authorize]
        public News add(News news)
        {
            return bll.add(news);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="news">新闻实体</param>
        /// <returns></returns>
        [HttpPost("upd")]
        [Authorize]
        public bool upd(News news)
        {
            return bll.upd(news);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">新闻id</param>
        /// <returns></returns>
        [HttpGet("del")]
        [Authorize]
        public bool del(int id)
        {
            string image = bll.get(id).Image;
            bool result = bll.del(id);
            if (result && !string.IsNullOrEmpty(image))
                BaseUtiliy.DeleteFile("/Image/news/cover", image);
            return result;
        }

        /// <summary>
        /// 封面上传
        /// </summary>
        /// <param name="keyValuePairs"></param>
        /// <returns></returns>
        [HttpPost("uploadImage")]
        [Authorize]
        public string updateImage([FromForm] IFormCollection keyValuePairs)
        {
            string result = "";
            FormFileCollection formFiles = (FormFileCollection)keyValuePairs.Files;
            foreach (FormFile file in formFiles)
            {
                result = BaseUtiliy.SaveFile(file.Name, "/Image/news/cover", file);
            }
            return result;
        }
    }
}
