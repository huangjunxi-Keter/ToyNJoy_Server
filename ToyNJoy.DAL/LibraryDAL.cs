using Microsoft.EntityFrameworkCore;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.DAL
{
    public class LibraryDAL
    {
        private ToyNjoyContext context;

        public LibraryDAL(ToyNjoyContext context)
        {
            this.context = context;
        }

        public IEnumerable<Library> find(string? userName, string productName, int? productId, int? productTypeId, 
            double? beginDays, double? endDays, string? orderby, int? page, int? count)
        {
            IQueryable<Library> result = context.Libraries;
            if (!string.IsNullOrEmpty(userName))
                result = result.Where(x => x.UserName.Equals(userName));
            if (!string.IsNullOrEmpty(productName))
                result = result.Where(x => x.Product.Name.Contains(productName));
            if (productId != null)
                result = result.Where(x => x.Product.Id == productId);
            if (productTypeId != null)
                result = result.Where(x => x.Product.TypeId == productTypeId);
            if (beginDays != null)
            {
                DateTime beginDate = DateTime.Now.AddDays(beginDays.Value);
                result = result.Where(x => x.LastTime > beginDate);
            }
            if (endDays != null)
            {
                DateTime endDate = DateTime.Now.AddDays(endDays.Value);
                result = result.Where(x => x.LastTime < endDate);
            }
            if (!string.IsNullOrEmpty(orderby))
            {
                switch (orderby)
                {
                    case "JoinTime":
                        result = result.OrderByDescending(x => x.JoinTime);
                        break;
                    case "LastTime":
                        result = result.OrderByDescending(x => x.LastTime);
                        break;
                    case "TotalHours":
                        result = result.OrderByDescending(x => x.TotalHours);
                        break;
                    case "Name":
                        result = result.OrderByDescending(x => x.Product.Name);
                        break;
                }
            }
            if (page != null && count != null)
                result = result.Skip((page * count).Value);
            if (count != null)
                result = result.Take(count.Value);

            return result.Include(x => x.Product);
        }

        public IEnumerable<Library> find(string username)
        {
            return context.Libraries.Where(l => l.UserName.Equals(username)).Include(x => x.Product);
        }

        public bool add(List<Library> libraries)
        {
            foreach (Library library in libraries)
            {
                context.Libraries.Add(library);
            }

            return context.SaveChanges() >= libraries.Count();
        }
    }
}
