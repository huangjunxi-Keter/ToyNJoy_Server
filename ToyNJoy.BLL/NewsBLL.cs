using ToyNJoy.DAL;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.BLL
{
    public class NewsBLL
    {
        private NewsDAL newsDAL;
        private ToyNjoyContext context;

        /// <summary>
        /// NewsBLL
        /// </summary>
        /// <param name="context">数据库上下文</param>
        public NewsBLL(ToyNjoyContext context)
        {
            this.context = context;
            newsDAL = new NewsDAL(context);
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
        public IEnumerable<News> find(string? title, string? text, DateTime? date, int? productId, int? typeId, string? orderby, int? page, int? count) 
        {
            return newsDAL.find(title, text, date, productId, typeId, orderby, page, count);
        }

        /// <summary>
        /// 查询新闻总数
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="text">内容</param>
        /// <param name="productId">产品id</param>
        /// <param name="typeId">类型id</param>
        /// <returns></returns>
        public int findCount(string? title, string? text, DateTime? date, int? productId, int? typeId)
        {
            return newsDAL.findCount(title, text, date, productId, typeId);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public News get(int id)
        {
            return newsDAL.get(id);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="news">新闻实体</param>
        /// <returns></returns>
        public News add(News news)
        {
            news.UpdateTime = DateTime.Now;
            return newsDAL.add(news);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="news">新闻实体</param>
        /// <returns></returns>
        public bool upd(News news)
        {
            news.UpdateTime = DateTime.Now;
            return newsDAL.upd(news);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">新闻id</param>
        /// <returns></returns>
        public bool del(int id)
        {
            return newsDAL.del(id);
        }
    }
}
