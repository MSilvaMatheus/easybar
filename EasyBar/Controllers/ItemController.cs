using EasyBar.Domain.TransferObjects;
using EasyBar.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EasyBar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IItemService _itemService;
        public ItemController(ILogger<ItemController> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        [HttpPost]
        public IActionResult Post(ItemDto itemDto)
        {
            try
            {
                return Ok(_itemService.Save(itemDto));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Ocorreu uma falha no cadastro do item");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_itemService.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Ocorreu uma falha na busca do item");
            }
        }

        [HttpPut]
        public IActionResult Put(ItemDto itemDto)
        {
            try
            {
                return Ok(_itemService.Update(itemDto));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Ocorreu uma falha na alteração do item");
            }
        }

        [HttpDelete]
        public IActionResult Delete(string identification)
        {
            try
            {
                return Ok(_itemService.Delete(identification));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Ocorreu uma falha na exclusão do item");
            }
        }
    }
}