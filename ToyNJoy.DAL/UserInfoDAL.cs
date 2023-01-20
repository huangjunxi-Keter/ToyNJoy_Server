using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.DAL
{
    public class UserInfoDAL
    {
        private ToyNjoyContext db = new ToyNjoyContext();

        public UserInfo getByName(string userName)
        {
            return db.UserInfos.FirstOrDefault(u => u.UserName.Equals(userName));
        }

        public bool upd(UserInfo userInfo)
        {
            db.Update(userInfo);
            return db.SaveChanges() > 0;
        }
    }
}
