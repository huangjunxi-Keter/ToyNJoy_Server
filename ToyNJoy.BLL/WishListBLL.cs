using ToyNJoy.DAL;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.BLL
{
    public class WishListBLL
    {
        private WishListDAL wishListDAL;
        private ToyNjoyContext context;

        public WishListBLL(ToyNjoyContext context)
        {
            this.context = context;
            wishListDAL = new WishListDAL(context);
        }

        public IEnumerable<WishList> find(string? userName, string? orderBy, string productName, 
            int? productId, int? productTypeId, int? productMinPrice, int? productMaxPrice)
        {
            return wishListDAL.find(userName, orderBy, productName, productId, productTypeId, productMinPrice, productMaxPrice);
        }

        public IEnumerable<WishList> find(int? prodictId)
        {
            return wishListDAL.find(prodictId);
        }
    }
}
