using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;
using ToyNJoy.Utiliy;

namespace ToyNJoy.DAL
{
    public class ProductDAL
    {
        private ToyNjoyContext db = new ToyNjoyContext();

        public bool add(Product p)
        {
            db.Add(p);
            return db.SaveChanges() > 0;
        }

        public bool del(string id)
        {
            db.Remove(id);
            return db.SaveChanges() > 0;
        }

        public bool upd(Product p)
        {
            db.Update(p);
            return db.SaveChanges() > 0;
        }

        public Product getById(int id) 
        {
            return db.Find<Product>(id);
        }

        public IEnumerable<Product> find(string? name, int? maxPrice, int? minPrice,
            int? typeId, string? orderby, int? page, int? count)
        {
            IEnumerable<Product> result = db.Products;
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
                result = result.OrderByDescending(x => BaseUtiliy.GetPropertyValue(x, orderby));
            if (page != null && count != null)
                result = result.Skip((page * count).Value);
            if (count != null)
                result = result.Take(count.Value);
            return result;
        }

        public int count(string? name, string? orderby)
        {
            IEnumerable<Product> result = db.Products;
            if (!string.IsNullOrEmpty(name))
                result = result.Where(x => x.Name.IndexOf(name) > -1);
            if (!string.IsNullOrEmpty(orderby))
                result = result.OrderByDescending(x => BaseUtiliy.GetPropertyValue(x, orderby));
            return result.Count();
        }
    }
}
