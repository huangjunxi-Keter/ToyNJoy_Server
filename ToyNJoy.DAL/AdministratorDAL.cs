using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.DAL
{
    public class AdministratorDAL
    {
        private ToyNjoyContext context;

        public AdministratorDAL(ToyNjoyContext context)
        {
            this.context = context;
        }

        public IEnumerable<Administrator> find(string saname) 
        {
            IEnumerable<Administrator> result = context.Administrators;
            if (!string.IsNullOrEmpty(saname)) 
            {
                result = result.Where(a => saname.Equals(a.SaName));
            }
            return result;
        }

        public Administrator get(int id)
        {
            Administrator result = context.Administrators.Find(id);
            return result;
        }
    }
}
