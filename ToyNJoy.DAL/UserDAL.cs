using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;
using Microsoft.EntityFrameworkCore.Storage;

namespace ToyNJoy.DAL
{
    public class UserDAL
    {
        private ToyNjoyContext context;

        public UserDAL(ToyNjoyContext context)
        {
            this.context = context;
        }

        public User Login(string userName, string passwor) 
        {
            return context.Users.Where(u => u.Username.Equals(userName) && u.Password.Equals(passwor)).FirstOrDefault();
        }

        public User get(string userName) 
        {
            return context.Users.Find(userName);
        }

        public bool upd(User user)
        {
            context.Update(user);
            return context.SaveChanges() > 0;
        }

        public bool add(User user, UserInfo userInfo) 
        {
            bool result = false;
            using (IDbContextTransaction dbContextTransaction = context.Database.BeginTransaction()) 
            {
                try
                {
                    context.Users.Add(user);
                    context.SaveChanges();

                    context.UserInfos.Add(userInfo);

                    result = context.SaveChanges() > 0;

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
