using ToyNJoy.DAL;
using ToyNJoy.Entity.Model;


namespace ToyNJoy.BLL
{
    public class UserInfoBLL
    {
        private UserInfoDAL dal = new UserInfoDAL();

        public UserInfo getByName(string userName) 
        {
            return dal.getByName(userName);
        }

        public bool upd(UserInfo userInfo)
        {
            return dal.upd(userInfo);
        }

        public bool add(UserInfo userInfo) 
        {
            return dal.add(userInfo);
        }
    }
}
