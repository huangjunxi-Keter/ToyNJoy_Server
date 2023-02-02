using Microsoft.EntityFrameworkCore;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;
using ToyNJoy.Utiliy;

namespace ToyNJoy.DAL
{
    public class NewsDAL
    {
        private ToyNjoyContext context;

        public NewsDAL(ToyNjoyContext context)
        {
            this.context = context;
        }

        public IEnumerable<News> find(string? title, string? text, int? prodoctId, string? orderby, int? count) 
        {
            IQueryable<News> result = context.News;
            if (prodoctId != null)
                result = result.Where(x => x.ProductId.Equals(prodoctId));
            if (!string.IsNullOrEmpty(title))
                result = result.Where(x => x.Title.IndexOf(title) > -1);
            if (!string.IsNullOrEmpty(text))
                result = result.Where(x => x.Text.IndexOf(text) > -1);
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
            if (count != null)
                result = result.Take(count.Value);
            return result;
        }
    }
}
