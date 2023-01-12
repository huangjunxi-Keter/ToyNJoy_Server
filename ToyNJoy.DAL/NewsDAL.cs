using Microsoft.EntityFrameworkCore;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;
using ToyNJoy.Utiliy;

namespace ToyNJoy.DAL
{
    public class NewsDAL
    {
        private ToyNjoyContext db = new ToyNjoyContext();

        public IEnumerable<News> find(string? title, string? text, int? prodoctId, string? orderby, int? count) 
        {
            IEnumerable<News> result = db.News;
            if (prodoctId != null)
                result = result.Where(x => x.ProductId.Equals(prodoctId));
            if (!string.IsNullOrEmpty(title))
                result = result.Where(x => x.Title.IndexOf(title) > -1);
            if (!string.IsNullOrEmpty(text))
                result = result.Where(x => x.Text.IndexOf(text) > -1);
            if (!string.IsNullOrEmpty(orderby))
                result = result.OrderByDescending(x => BaseUtiliy.GetPropertyValue(x, orderby));
            if (count != null)
                result = result.Take(count.Value);
            return result;
        }
    }
}
