using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Product> find(string? name, string? orderby, int? count)
        {
            IEnumerable<Product> result = db.Products;
            if (!string.IsNullOrEmpty(name))
                result = result.Where(x => x.Name.IndexOf(name) > -1);
            if (!string.IsNullOrEmpty(orderby))
                result = result.OrderByDescending(x => BaseUtiliy.GetPropertyValue(x, orderby));
            if (count != null)
                result = result.Take(count.Value);
            return result;
        }
    }
}
