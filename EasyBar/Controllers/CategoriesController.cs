using EasyBar.Domain.TransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EasyBar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ILogger<CategoriesController>  logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post(CategoriesDto categoriesDto)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu uma falha no cadastro de Categoria");
            }
        }
    }
}
