using ToyNJoy.DAL;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.BLL
{
    public class ShoppingCarBLL
    {
        private ShoppingCarDAL dal = new ShoppingCarDAL();

        public IEnumerable<ShoppingCar> find(string? userName)
        {
            return dal.find(userName);
        }
    }
}
