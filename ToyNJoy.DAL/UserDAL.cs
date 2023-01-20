using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.DAL
{
    public class UserDAL
    {
        private ToyNjoyContext db = new ToyNjoyContext();

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
    }
}
