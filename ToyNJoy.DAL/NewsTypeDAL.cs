using Microsoft.EntityFrameworkCore;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.DAL
{
    public class NewsTypeDAL
    {
        private ToyNjoyContext context;

        public NewsTypeDAL(ToyNjoyContext context)
        {
            this.context = context;
        }

        public IEnumerable<NewsType> find(string? name, int? state, int? page, int? count)
        {
            IEnumerable<NewsType> result = context.NewsTypes;
            if (!string.IsNullOrEmpty(name))
                result = result.Where(n => n.TypeName.Contains(name));
            if (state != null)
                result = result.Where(n => n.State == state);
            if (page != null && count != null)
                result.Skip((page * count).Value);
            if (count != null)
                result = result.Take(count.Value);

            return result;
        }

        public int findCount(string? name, int? state)
        {
            IEnumerable<NewsType> newsTypes = context.NewsTypes;
            if (!string.IsNullOrEmpty(name))
                newsTypes = newsTypes.Where(n => n.TypeName.Contains(name));
            if (state != null)
                newsTypes = newsTypes.Where(n => n.State == state);

            return newsTypes.Count();
        }

        public bool add(NewsType newsType)
        {
            context.Add(newsType);
            return context.SaveChanges() > 0;
        }

        public bool upd(NewsType newsType)
        {
            context.Update(newsType);
            return context.SaveChanges() > 0;
        }

        public bool del(int id)
        {
            context.NewsTypes.Where(n => n.Id == id).ExecuteDelete();
            return context.SaveChanges() > 0;
        }
    }
}
