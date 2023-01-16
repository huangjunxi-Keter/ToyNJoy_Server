using ToyNJoy.DAL;
using ToyNJoy.Entity.Model;


namespace ToyNJoy.BLL
{
    public class UserBLL
    {
        private UserDAL dal = new UserDAL();

        public User Login(string userName, string password)
        {
            return dal.Login(userName, password);
        }
    }
}
