using Microsoft.EntityFrameworkCore;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.DAL
{
    public class ShoppingCarDAL
    {
        private ToyNjoyContext context;

        public ShoppingCarDAL(ToyNjoyContext context)
        {
            this.context = context;
        }

        public IEnumerable<ShoppingCar> find(string? userName, int? productId) 
        {
            IQueryable<ShoppingCar> result = context.ShoppingCars;

            if (!string.IsNullOrEmpty(userName))
                result = result.Where(s => s.UserName.Equals(userName));
            if (productId != null)
                result = result.Where(s => s.ProductId.Equals(productId));

            return result.Include(s => s.Product);
        }

        public bool add(ShoppingCar shoppingCar)
        {
            context.ShoppingCars.Add(shoppingCar);
            return context.SaveChanges() > 0;
        }

        public bool del(string userName)
        {
            context.ShoppingCars.Where(s => s.UserName.Equals(userName)).ExecuteDelete();
            return context.SaveChanges() > 0;
        }

        public bool del(int? id)
        {
            bool result = false;
            try
            {
                if (id != null)
                {
                    context.ShoppingCars.Where(s => s.Id == id).ExecuteDelete();
                    context?.SaveChanges();
                    result = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
