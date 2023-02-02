using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;
using ToyNJoy.Utiliy;

namespace ToyNJoy.DAL
{
    public class ProductDAL
    {
        private ToyNjoyContext context;

        public ProductDAL(ToyNjoyContext context)
        {
            this.context = context;
        }

        public bool add(Product p)
        {
            context.Add(p);
            return context.SaveChanges() > 0;
        }

        public bool del(string id)
        {
            context.Remove(id);
            return context.SaveChanges() > 0;
        }

        public bool upd(Product p)
        {
            context.Update(p);
            return context.SaveChanges() > 0;
        }

        public Product getById(int id) 
        {
            return context.Find<Product>(id);
        }

        public IEnumerable<Product> find(string? name, int? maxPrice, int? minPrice,
            int? typeId, string? orderby, int? page, int? count)
        {
            IQueryable<Product> result = context.Products;
            if (!string.IsNullOrEmpty(name))
                result = result.Where(x => x.Name.Contains(name));
            if (maxPrice != null)
                result = result.Where(x => x.Price <= maxPrice);
            if (minPrice != null)
                result = result.Where(x => x.Price >= minPrice);
            if (typeId != null)
                result = result.Where(x => x.TypeId == typeId);
            // 条件筛选完后再进行排序和分页
            if (!string.IsNullOrEmpty(orderby))
            {
                switch (orderby)
                {
                    case "Name":
                        result = result.OrderByDescending(x => x.Name);
                        break;
                    case "Price":
                        result = result.OrderByDescending(x => x.Price);
                        break;
                    case "ReleaseDate":
                        result = result.OrderByDescending(x => x.ReleaseDate);
                        break;
                    case "Browse":
                        result = result.OrderByDescending(x => x.Browse);
                        break;
                    case "Purchases":
                        result = result.OrderByDescending(x => x.Purchases);
                        break;
                    case "Discount":
                        result = result.OrderByDescending(x => x.Discount);
                        break;
                }
            }
            if (page != null && count != null)
                result = result.Skip((page * count).Value);
            if (count != null)
                result = result.Take(count.Value);
            return result;
        }

        public int count(string? name, string? orderby)
        {
            IQueryable<Product> result = context.Products;
            if (!string.IsNullOrEmpty(name))
                result = result.Where(x => x.Name.IndexOf(name) > -1);
            if (!string.IsNullOrEmpty(orderby))
            {
                switch (orderby)
                {
                    case "Name":
                        result = result.OrderByDescending(x => x.Name);
                        break;
                    case "Price":
                        result = result.OrderByDescending(x => x.Price);
                        break;
                    case "ReleaseDate":
                        result = result.OrderByDescending(x => x.ReleaseDate);
                        break;
                    case "Browse":
                        result = result.OrderByDescending(x => x.Browse);
                        break;
                    case "Purchases":
                        result = result.OrderByDescending(x => x.Purchases);
                        break;
                    case "Discount":
                        result = result.OrderByDescending(x => x.Discount);
                        break;
                }
            }
            return result.Count();
        }
    }
}
