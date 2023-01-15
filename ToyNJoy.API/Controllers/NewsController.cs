using Microsoft.AspNetCore.Mvc;
using ToyNJoy.BLL;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : Controller
    {
        private readonly ILogger<NewsController> _logger;

        public NewsController(ILogger<NewsController> logger)
        {
            _logger = logger;
        }

        private NewsBLL bll = new NewsBLL();

        [HttpGet("find")]
        public IEnumerable<News> find(string? title, string? text, int? prodoctId, string? orderby, int? count) 
        {
            return bll.find(title, text, prodoctId, orderby, count);
        }
    }
}
