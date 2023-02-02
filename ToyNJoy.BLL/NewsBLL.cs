using ToyNJoy.DAL;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.BLL
{
    public class NewsBLL
    {
        private NewsDAL newsDAL;
        private ToyNjoyContext context;

        public NewsBLL(ToyNjoyContext context)
        {
            this.context = context;
            newsDAL = new NewsDAL(context);
        }

        public IEnumerable<News> find(string? title, string? text, int? prodoctId, string? orderby, int? count) 
        {
            return newsDAL.find(title, text, prodoctId, orderby, count);
        }
    }
}
