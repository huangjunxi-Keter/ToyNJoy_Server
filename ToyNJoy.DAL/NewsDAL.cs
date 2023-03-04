using Microsoft.EntityFrameworkCore;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.DAL
{
    public class NewsDAL
    {
        private ToyNjoyContext context;

        public NewsDAL(ToyNjoyContext context)
        {
            this.context = context;
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
            IQueryable<News> result = context.News;
            if (productId != null)
                result = result.Where(x => x.ProductId.Equals(productId));
            if (typeId != null)
                result = result.Where(x => x.TypeId == typeId);
            if (!string.IsNullOrEmpty(title))
                result = result.Where(x => x.Title.Contains(title));
            if (!string.IsNullOrEmpty(text))
                result = result.Where(x => x.Text.Contains(text));
            if (!string.IsNullOrEmpty(orderby))
            {
                switch (orderby)
                {
                    case "Title":
                        result = result.OrderByDescending(x => x.Title);
                        break;
                    case "PageView":
                        result = result.OrderByDescending(x => x.PageView);
                        break;
                    case "Commend":
                        result = result.OrderByDescending(x => x.Commend);
                        break;
                    case "Trample":
                        result = result.OrderByDescending(x => x.Trample);
                        break;
                    case "UpdateTime":
                        result = result.OrderByDescending(x => x.UpdateTime);
                        break;
                }
            }
            if (page != null && count != null)
                result = result.Skip((page * count).Value);
            if (count != null)
                result = result.Take(count.Value);
            return result;
        }

        /// <summary>
        /// 查询新闻总数
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="text">内容</param>
        /// <param name="productId">产品id</param>
        /// <param name="typeId">类型id</param>
        public int findCount(string? title, string? text, int? productId, int? typeId)
        {
            IQueryable<News> news = context.News;
            if (productId != null)
                news = news.Where(x => x.ProductId.Equals(productId));
            if (typeId != null)
                news = news.Where(x => x.TypeId == typeId);
            if (!string.IsNullOrEmpty(title))
                news = news.Where(x => x.Title.Contains(title));
            if (!string.IsNullOrEmpty(text))
                news = news.Where(x => x.Text.Contains(text));

            return news.Count();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="news">新闻实体</param>
        /// <returns></returns>
        public bool add(News news)
        {
            context.Add(news);
            return context.SaveChanges() > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="news">新闻实体</param>
        /// <returns></returns>
        public bool upd(News news)
        {
            context.Update(news);
            return context.SaveChanges() > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">新闻id</param>
        /// <returns></returns>
        public bool del(int id)
        {
            context.News.Where(n => n.Id == id).ExecuteDelete();
            return context.SaveChanges() > 0;
        }
    }
}
