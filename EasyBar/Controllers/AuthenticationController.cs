using EasyBar.Domain.Entity.Authentication;
using EasyBar.Domain.TransferObjects;
using EasyBar.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EasyBar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthenticationController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]  
        public IActionResult Login(LoginDto credentialsEntity)
        {
            try
            {
                var token = _tokenService.Generate(credentialsEntity);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um falha no servidor, por favor entrar em contato com o Administrador");
            }
        }
    }
}
