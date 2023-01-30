using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;
using Microsoft.EntityFrameworkCore;
using ToyNJoy.Utiliy;

namespace ToyNJoy.DAL
{
    public class WishListDAL
    {
        private ToyNjoyContext db = new ToyNjoyContext();

        public IEnumerable<WishList> find(string? userName, string? orderBy, string productName, int? productTypeId, int? productMinPrice, int? productMaxPrice)
        {
            IEnumerable<WishList> result = db.WishLists.Include(w => w.Product);
            if (!string.IsNullOrEmpty(userName))
                result = result.Where(w => w.UserName.Equals(userName));
            if (!string.IsNullOrEmpty(productName))
                result = result.Where(w => w.Product.Name.Contains(productName));
            if (productTypeId != null)
                result = result.Where(w => w.Product.TypeId == productTypeId);
            if (productMinPrice != null)
                result = result.Where(w => w.Product.Price >= productMinPrice);
            if (productMaxPrice != null)
                result = result.Where(w => w.Product.Price <= productMaxPrice);
            if (!string.IsNullOrEmpty(orderBy)) 
            {
                if (orderBy.Contains("product."))
                    result = result.OrderByDescending(w => BaseUtiliy.GetPropertyValue(w.Product, orderBy.Split(".")[1]));
                else
                    result = result.OrderByDescending(w => BaseUtiliy.GetPropertyValue(w, orderBy));
            }

            return result;
        }
    }
}
