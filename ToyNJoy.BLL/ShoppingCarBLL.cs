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

        public IEnumerable<ShoppingCar> find(string? userName, int? productId)
        {
            return shoppingCarDAL.find(userName, productId);
        }

        public bool add(string userName, int productId)
        {
            ShoppingCar shoppingCar = new ShoppingCar();
            shoppingCar.UserName = userName;
            shoppingCar.ProductId = productId;
            return shoppingCarDAL.add(shoppingCar);
        }

        public bool del(int? id)
        {
            return shoppingCarDAL.del(id);
        }
    }
}
