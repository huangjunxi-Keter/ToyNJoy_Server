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
        /// <param name="productId">产品id</param>
        /// <param name="typeId">类型id</param>
        /// <param name="orderby">排序方式</param>
        /// <param name="page">当前页减一</param>
        /// <param name="count">总条数</param>
        /// <returns></returns>
        public IEnumerable<News> find(string? title, string? text, int? productId, int? typeId, string? orderby, int? page, int? count) 
        {
            return newsDAL.find(title, text, productId, typeId, orderby, page, count);
        }

        /// <summary>
        /// 查询新闻总数
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="text">内容</param>
        /// <param name="productId">产品id</param>
        /// <param name="typeId">类型id</param>
        /// <returns></returns>
        public int findCount(string? title, string? text, int? productId, int? typeId)
        {
            return newsDAL.findCount(title, text, productId, typeId);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="news">新闻实体</param>
        /// <returns></returns>
        public bool add(News news)
        {
            return newsDAL.add(news);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="news">新闻实体</param>
        /// <returns></returns>
        public bool upd(News news)
        {
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
