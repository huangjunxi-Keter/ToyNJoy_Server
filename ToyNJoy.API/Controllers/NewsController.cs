using Microsoft.AspNetCore.Mvc;
using ToyNJoy.BLL;
using ToyNJoy.Entity.Model;
using ToyNJoy.Entity;

namespace ToyNJoy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : Controller
    {
        private readonly ILogger<NewsController> logger;
        private NewsBLL bll;

        public NewsController(ILogger<NewsController> logger, ToyNjoyContext context)
        {
            this.logger = logger;
            bll = new NewsBLL(context);
        }

        [HttpGet("find")]
        public IEnumerable<News> find(string? title, string? text, int? prodoctId, string? orderby, int? count) 
        {
            return bll.find(title, text, prodoctId, orderby, count);
        }
    }
}
