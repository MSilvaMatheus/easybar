using EasyBar.Domain.TransferObjects;
using EasyBar.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EasyBar.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        private readonly ILogger<ConsumerController> _logger;
        private readonly IConsumerService _consumerService;

        public ConsumerController(ILogger<ConsumerController> logger, IConsumerService consumerService)
        {
            _logger = logger;
            _consumerService = consumerService;
        }

        [HttpPost]
        public IActionResult Post(ConsumerDto consumer)
        {
            try
            {
                return Ok(_consumerService.Save(consumer));
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
                return Ok(_consumerService.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Ocorreu uma falha na busca de Mesa");
            }
        }

        [HttpPut]
        public IActionResult Put(ConsumerDto consumer)
        {
            try
            {
                return Ok(_consumerService.Update(consumer));
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
                return Ok(_consumerService.Delete(identification));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Ocorreu uma falha na exclusão de Mesa");
            }
        }

        [HttpGet]
        [Route("GetByNumber")]
        public IActionResult Get(long number)
        {
            try
            {
                return Ok(_consumerService.Get(0));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Ocorreu uma falha na busca de Mesa");
            }
        }
    }
}