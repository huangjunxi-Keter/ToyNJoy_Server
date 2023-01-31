using Microsoft.EntityFrameworkCore;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.DAL
{
    public class ShoppingCarDAL
    {
        private ToyNjoyContext db = new ToyNjoyContext();

        public IEnumerable<ShoppingCar> find(string? userName) 
        {
            IEnumerable<ShoppingCar> result = db.ShoppingCars.Include(s => s.Product);

            if (!string.IsNullOrEmpty(userName))
                result = result.Where(s => s.UserName.Equals(userName));

            return result;
        }
    }
}
