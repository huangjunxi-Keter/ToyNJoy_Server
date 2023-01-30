using ToyNJoy.DAL;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.BLL
{
    public class LibraryBLL
    {
        private LibraryDAL dal = new LibraryDAL();

        public IEnumerable<Library> find(string? username, double? beginDays, double? endDays)
        {
            return dal.find(username, beginDays, endDays);
        }
    }
}
