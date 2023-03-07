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

        public bool add(string username, int productId)
        { 
            WishList wishList = new WishList();
            wishList.UserName = username;
            wishList.ProductId = productId;
            wishList.SerialNamber = wishListDAL.find(username, null, null, null, null, null, null).Count() + 1;
            wishList.JoinDate = DateTime.Now;

            return wishListDAL.add(wishList);
        }

        public bool del(int id)
        {
            return wishListDAL.del(id);
        }
    }
}
