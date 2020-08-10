using EasyBar.Domain.TransferObjects;
using EasyBar.Service.Interface;
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
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpPost]
        public IActionResult Post(CategoriesDto categoriesDto)
        {
            try
            {
                var teste = _categoriesService.Save(categoriesDto);
                return Ok(teste);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu uma falha no cadastro de Categoria");
            }
        }
    }
}
