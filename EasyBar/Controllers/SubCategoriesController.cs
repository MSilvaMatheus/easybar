using EasyBar.Domain.TransferObjects;
using EasyBar.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EasyBar.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class SubCategoriesController : ControllerBase
    {
        private readonly ISubCategoriesService _subCategoriesService;
        private readonly ILogger<SubCategoriesController> _logger;

        public SubCategoriesController(ISubCategoriesService subCategoriesService, ILogger<SubCategoriesController> logger)
        {
            _logger = logger;
            _subCategoriesService = subCategoriesService;
        }
        
        [HttpPost]
        public IActionResult Post(SubCategoriesDto categoriesDto)
        {
            try
            {
                return Ok(_subCategoriesService.Save(categoriesDto));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Ocorreu uma falha no cadastro da subcategoria");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_subCategoriesService.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Ocorreu uma falha na busca da subcategoria");
            }
        }

        [HttpPut]
        public IActionResult Put(SubCategoriesDto categoriesDto)
        {
            try
            {
                return Ok(_subCategoriesService.Update(categoriesDto));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Ocorreu uma falha na alteração da subcategoria");
            }
        }

        [HttpDelete]
        public IActionResult Delete(string identification)
        {
            try
            {
                return Ok(_subCategoriesService.Delete(identification));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Ocorreu uma falha na exclusão da subcategoria");
            }
        }

        //[HttpGet]
        //[Route("GetByCategorieName")]
        //public IActionResult Get(string name)
        //{
        //    try
        //    {
        //        return Ok(_subCategoriesService.GetByCategoriesName(name));
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        return BadRequest("Ocorreu uma falha na busca de Mesa");
        //    }
        //}
    }  
}