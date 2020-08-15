using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EasyBar.Domain.TransferObjects;
using EasyBar.Service.Interface;
using System;

namespace EasyBar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TableController : ControllerBase
    {
        private readonly ILogger<TableController> _logger;
        private readonly ITableService _tableService;

        public TableController(ILogger<TableController> logger, ITableService tableService)
        {
            _tableService = tableService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post(TableDto categoriesDto)
        {
            try
            {
                return Ok(_tableService.Save(categoriesDto));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Ocorreu uma falha no cadastro de Mesa");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tableService.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Ocorreu uma falha na busca de Mesa");
            }
        }

        [HttpPut]
        public IActionResult Put(TableDto categoriesDto)
        {
            try
            {
                return Ok(_tableService.Update(categoriesDto));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Ocorreu uma falha na alteração de Mesa");
            }
        }

        [HttpDelete]
        public IActionResult Delete(string identification)
        {
            try
            {
                return Ok(_tableService.Delete(identification));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Ocorreu uma falha na exclusão de Mesa");
            }
        }

        [HttpGet]
        [Route("GetByNumber")]
        public IActionResult Get(int number)
        {
            try
            {
                return Ok(_tableService.Get(number));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Ocorreu uma falha na busca de Mesa");
            }
        }
    }
}
