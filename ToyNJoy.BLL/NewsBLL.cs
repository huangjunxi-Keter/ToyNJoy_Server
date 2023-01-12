using ToyNJoy.DAL;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.BLL
{
    public class NewsBLL
    {
        private NewsDAL dal = new NewsDAL();

        public IEnumerable<News> find(string? title, string? text, int? prodoctId, string? orderby, int? count) 
        {
            return dal.find(title, text, prodoctId, orderby, count);
        }
    }
}
