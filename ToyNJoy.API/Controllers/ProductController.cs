using Microsoft.AspNetCore.Mvc;
using ToyNJoy.BLL;
using ToyNJoy.Entity.Model;

namespace ToyNJoy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public ProductController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        private ProductBLL bll = new ProductBLL();

        [HttpGet("find")]
        public IEnumerable<Product> find(string? name, string? orderby, int? count)
        {
            return bll.find(name, orderby, count);
        }
        
        [HttpPost("add")]
        public IEnumerable<Product> add([FromBody] Product p)
        {
            /*
                axios ���� api ʵ�������
                1. 400 Content-Type ������
                2. 415 key ��һ�£����Ͳ�һ�£�string or json����û���ش�ֵ��ʵ�����н�β�� = null!�����ԣ�
            */

            return bll.find(null, null, 4);
        }
    }
}