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

        public IEnumerable<User> find(string? username, string? nickname, string? email, int? lv, int? state, int? typeId, int? page, int? count)
        {
            IEnumerable<User> result = context.Users;
            if (!string.IsNullOrEmpty(username))
                result = result.Where(x => x.Username.Contains(username));
            if (!string.IsNullOrEmpty(nickname))
                result = result.Where(x => x.Nickname.Contains(nickname));
            if (!string.IsNullOrEmpty(email))
                result = result.Where(x => x.Email.Contains(email));
            if (lv != null)
                result = result.Where(x => x.Lv == lv);
            if (state != null)
                result = result.Where(x => x.State == state);
            if (typeId != null)
                result = result.Where(x => x.TypeId == typeId);
            if (page != null && count != null)
                result = result.Skip((page * count).Value);
            if (count != null)
                result = result.Take(count.Value);

            return result;
        }

        public IEnumerable<User> find(List<string> usernames)
        {
            return context.Users.Where(u => usernames.Contains(u.Username));
        }

        public int findCount(string? username, string? nickname, string? email, int? lv, int? state, int? typeId)
        {
            IEnumerable<User> result = context.Users;
            if (!string.IsNullOrEmpty(username))
                result = result.Where(x => x.Username.Contains(username));
            if (!string.IsNullOrEmpty(nickname))
                result = result.Where(x => x.Nickname.Contains(nickname));
            if (!string.IsNullOrEmpty(email))
                result = result.Where(x => x.Email.Contains(email));
            if (lv != null)
                result = result.Where(x => x.Lv == lv);
            if (state != null)
                result = result.Where(x => x.State == state);
            if (typeId != null)
                result = result.Where(x => x.TypeId == typeId);

            return result.Count();
        }

        public User Login(string userName, string passwor, int? typeId)
        {
            IQueryable<User> users = context.Users;
            if (typeId != null)
                users = users.Where(u => u.TypeId == typeId);
            return users.Where(u => u.Username.Equals(userName) && u.Password.Equals(passwor)).FirstOrDefault();
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
