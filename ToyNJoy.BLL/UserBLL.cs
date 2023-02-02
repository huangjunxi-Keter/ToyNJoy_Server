using ToyNJoy.DAL;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;


namespace ToyNJoy.BLL
{
    public class UserBLL
    {
        private UserDAL userDAL;
        private ToyNjoyContext context;

        public UserBLL(ToyNjoyContext context)
        {
            this.context = context;
            userDAL = new UserDAL(context);
        }

        public User Login(string userName, string password)
        {
            return userDAL.Login(userName, password);
        }

        public User get(string userName) 
        {
            return userDAL.get(userName);
        }

        public bool upd(User user)
        {
            return userDAL.upd(user);
        }

        public string add(User user)
        {
            string result = "添加失败！";

            User userDB = userDAL.get(user.Username);
            if (userDB == null)
            {
                user.Nickname = user.Username;
                user.Lv = 0;
                user.VirtualImage = ".png";
                user.RegisterTime = DateTime.Now;
                user.State = 0;

                UserInfo userInfo = new UserInfo();
                userInfo.UserName = user.Username;
                userInfo.Signature = "这个人懒死了，什么都没写";
                Random r = new Random();
                userInfo.WrapperImage = string.Format("ToyNJoy({0}).jpg", r.Next(1, 4));

                if (userDAL.add(user, userInfo))
                    result = "注册成功！";
            }
            else
                result = "用户名已存在！";

            return result;
        }
    }
}
