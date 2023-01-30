using ToyNJoy.DAL;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.BLL
{
    public class WishListBLL
    {
        private WishListDAL dal = new WishListDAL();

        public IEnumerable<WishList> find(string? userName, string? orderBy, string productName, 
            int? productTypeId, int? productMinPrice, int? productMaxPrice)
        {
            return dal.find(userName, orderBy, productName, productTypeId, productMinPrice, productMaxPrice);
        }
    }
}
