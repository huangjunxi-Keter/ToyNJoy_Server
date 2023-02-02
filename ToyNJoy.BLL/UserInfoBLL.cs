using ToyNJoy.DAL;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;


namespace ToyNJoy.BLL
{
    public class UserInfoBLL
    {
        private UserInfoDAL userInfoDAL;
        private ToyNjoyContext context;

        public UserInfoBLL(ToyNjoyContext context)
        {
            this.context = context;
            userInfoDAL = new UserInfoDAL(context);
        }

        public UserInfo getByName(string userName) 
        {
            return userInfoDAL.getByName(userName);
        }

        public bool upd(UserInfo userInfo)
        {
            return userInfoDAL.upd(userInfo);
        }

        public bool add(UserInfo userInfo) 
        {
            return userInfoDAL.add(userInfo);
        }
    }
}
