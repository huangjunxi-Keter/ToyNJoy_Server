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

        public IEnumerable<ShoppingCar> find(string? userName) 
        {
            IQueryable<ShoppingCar> result = context.ShoppingCars;

            if (!string.IsNullOrEmpty(userName))
                result = result.Where(s => s.UserName.Equals(userName));

            return result.Include(s => s.Product);
        }

        public bool del(string userName)
        {
            context.ShoppingCars.Where(s => s.UserName.Equals(userName)).ExecuteDelete();
            return context.SaveChanges() > 0;
        }
    }
}
