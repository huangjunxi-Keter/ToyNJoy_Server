using ToyNJoy.DAL;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.BLL
{
    public class ShoppingCarBLL
    {
        private ShoppingCarDAL shoppingCarDAL;
        private ToyNjoyContext context;

        public ShoppingCarBLL(ToyNjoyContext context)
        {
            this.context = context;
            shoppingCarDAL = new ShoppingCarDAL(context);
        }

        public IEnumerable<ShoppingCar> find(string? userName)
        {
            return shoppingCarDAL.find(userName);
        }
    }
}
