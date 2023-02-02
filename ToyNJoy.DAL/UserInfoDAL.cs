using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.DAL
{
    public class UserInfoDAL
    {
        private ToyNjoyContext context;

        public UserInfoDAL(ToyNjoyContext context)
        {
            this.context = context;
        }

        public UserInfo getByName(string userName)
        {
            return context.UserInfos.FirstOrDefault(u => u.UserName.Equals(userName));
        }

        public bool upd(UserInfo userInfo)
        {
            context.Update(userInfo);
            return context.SaveChanges() > 0;
        }

        public bool add(UserInfo userInfo)
        {
            context.UserInfos.Add(userInfo);
            return context.SaveChanges() > 0;
        }
    }
}
