using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;
using Microsoft.EntityFrameworkCore.Storage;

namespace ToyNJoy.DAL
{
    public class UserDAL
    {
        private ToyNjoyContext db = new ToyNjoyContext();
        //private UserInfoDAL userInfoDAL = new UserInfoDAL();

        public User Login(string userName, string passwor) 
        {
            return db.Users.Where(u => u.Username.Equals(userName) && u.Password.Equals(passwor)).FirstOrDefault();
        }

        public User getByName(string userName) 
        {
            return db.Users.Find(userName);
        }

        public bool upd(User user)
        {
            db.Update(user);
            return db.SaveChanges() > 0;
        }

        public bool add(User user, UserInfo userInfo) 
        {
            bool result = false;
            using (IDbContextTransaction dbContextTransaction = db.Database.BeginTransaction()) 
            {
                try
                {
                    db.Users.Add(user);
                    db.SaveChanges();

                    db.UserInfos.Add(userInfo);

                    result = db.SaveChanges() > 0;

                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                }
            }
            return result;
        }
    }
}
