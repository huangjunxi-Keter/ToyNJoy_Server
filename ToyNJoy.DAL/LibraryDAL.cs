using Microsoft.EntityFrameworkCore;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.DAL
{
    public class LibraryDAL
    {
        private ToyNjoyContext db = new ToyNjoyContext();

        public IEnumerable<Library> find(string? username, double? beginDays, double? endDays)
        {
            IEnumerable<Library> result = db.Libraries.Include(x => x.Product);
            if (string.IsNullOrEmpty(username))
                result = result.Where(x => x.UserName.Equals(username));
            if (beginDays != null)
            {
                DateTime beginDate = DateTime.Now.AddDays(beginDays.Value);
                result = result.Where(x => x.LastTime > beginDate);
            }
            if (endDays != null)
            {
                DateTime endDate = DateTime.Now.AddDays(endDays.Value);
                result = result.Where(x => x.LastTime < endDate);
            }
            return result;
        }
    }
}
