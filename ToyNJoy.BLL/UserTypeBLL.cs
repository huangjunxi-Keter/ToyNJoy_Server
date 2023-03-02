using ToyNJoy.Entity.Model;
using ToyNJoy.DAL;
using ToyNJoy.Entity;

namespace ToyNJoy.BLL
{
    public class UserTypeBLL
    {
        private UserTypeDAL UserTypeDAL;
        private ToyNjoyContext context;

        public UserTypeBLL(ToyNjoyContext context)
        {
            this.context = context;
            UserTypeDAL = new UserTypeDAL(context);
        }

        public IEnumerable<UserType> find(string name, int? state, int? page, int? count)
        {
            return UserTypeDAL.find(name, state, page, count);
        }

        public int findCount(string name, int? state)
        {
            return UserTypeDAL.findCount(name, state);
        }

        public bool add(UserType UserType)
        {
            return UserTypeDAL.add(UserType);
        }

        public bool upd(UserType UserType)
        {
            return UserTypeDAL.upd(UserType);
        }

        public bool del(int id)
        {
            return UserTypeDAL.del(id);
        }
    }
}
