using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace ToyNJoy.DAL
{
    public class UserTypeDAL
    {
        private ToyNjoyContext context;

        public UserTypeDAL(ToyNjoyContext context)
        {
            this.context = context;
        }

        public IEnumerable<UserType> find(string name, int? state, int? page, int? count) 
        {
            IQueryable<UserType> result = context.UserTypes;
            if (!string.IsNullOrEmpty(name))
                result = result.Where(x => x.TypeName.Contains(name));
            if (state != null)
                result = result.Where(x => x.State == state);
            if (page != null && count != null)
                result = result.Skip((page * count).Value);
            if (count != null)
                result = result.Take(count.Value);

            return result;
        }

        public int findCount(string name, int? state)
        {
            IEnumerable<UserType> result = context.UserTypes;
            if (!string.IsNullOrEmpty(name))
                result = result.Where(x => x.TypeName.Contains(name));
            if (state != null)
                result = result.Where(x => x.State == state);
            return result.Count();
        }

        public bool add(UserType UserType)
        {
            context.UserTypes.Add(UserType);
            return context.SaveChanges() > 0;
        }

        public bool upd(UserType UserType)
        {
            context.UserTypes.Update(UserType);
            return context.SaveChanges() > 0;
        }

        public bool del(int id)
        {
            bool result = false;
            try
            {
                context.UserTypes.Where(x => x.Id == id).ExecuteDelete();
                context.SaveChanges();
                result = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
    }
}
