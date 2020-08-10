using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EasyBar.Domain.TransferObjects;

namespace EasyBar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TableController : ControllerBase
    {
        private readonly ILogger<TableController> _logger;
        //private readonly ITableService _tableService;

        //public TableController(ILogger<TableController> logger, ITableService tableService)
        //{
        //    _tableService = tableService;
        //    _logger = logger;
        //}

        //[HttpGet]
        //public IActionResult<TableDto> Get()
        //{
        //    return "I am API EasyBar";
        //}

        //[HttpPost]
        //public IActionResult Post(TableDto table) 
        //{
        //  try
        //  {
        //    return Ok(_tableService.Save(table));
        //  }
        //  catch(Exception ex) 
        //  {
        //    return BadRequest("Ocorreu um erro ao cadastrar uma mesa nova, entre em contato com o Administrador! " + ex.Message);
        //  }
        //}
        //}]
    }
}
