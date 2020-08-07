using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EasyBar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {      
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "I am API EasyBar";
        }
    }
}
