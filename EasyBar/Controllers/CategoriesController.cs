﻿using EasyBar.Domain.TransferObjects;
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

        public CategoriesController(ICategoriesService categoriesService, ILogger<CategoriesController> logger)
        {
            _categoriesService = categoriesService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post(CategoriesDto categoriesDto)
        {
            try
            {
                return Ok(_categoriesService.Save(categoriesDto));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Ocorreu uma falha no cadastro de Categoria");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_categoriesService.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Ocorreu uma falha na busca de Categorias");
            }
        }

        [HttpPut]
        public IActionResult Put(CategoriesDto categoriesDto)
        {
            try
            {
                return Ok(_categoriesService.Update(categoriesDto));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Ocorreu uma falha na alteração de Categorias");
            }
        }

        [HttpDelete]
        public IActionResult Delete(string identification)
        {
            try
            {
                return Ok(_categoriesService.Delete(identification));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Ocorreu uma falha na exclusão de Categoria");
            }
        }
    }
}
