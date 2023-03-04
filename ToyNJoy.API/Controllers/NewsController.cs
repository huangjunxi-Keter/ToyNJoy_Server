using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToyNJoy.BLL;
using ToyNJoy.Entity.Model;
using ToyNJoy.Entity;

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
        /// <param name="productId">产品id</param>
        /// <param name="typeId">类型id</param>
        /// <param name="orderby">排序方式</param>
        /// <param name="page">当前页减一</param>
        /// <param name="count">总条数</param>
        /// <returns></returns>

        [HttpGet("find")]
        public IEnumerable<News> find(string? title, string? text, int? productId, int? typeId, string? orderby, int? page, int? count)
        {
            return bll.find(title, text, productId, typeId, orderby, page, count);
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
        public int findCount(string? title, string? text, int? productId, int? typeId)
        {
            return bll.findCount(title, text, productId, typeId);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="news">新闻实体</param>
        /// <returns></returns>
        [HttpGet("add")]
        [Authorize]
        public bool add(News news)
        {
            return bll.add(news);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="news">新闻实体</param>
        /// <returns></returns>
        [HttpGet("upd")]
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
            return bll.del(id);
        }
    }
}
