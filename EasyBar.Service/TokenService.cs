using EasyBar.Domain.Entity.Authentication;
using EasyBar.Domain.Entity.Validation;
using EasyBar.Domain.Interfaces;
using EasyBar.Domain.Interfaces.Repository;
using EasyBar.Domain.TransferObjects;
using EasyBar.Service.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EasyBar.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IConsumerRepository _consumerRepository;

        public TokenService(IConfiguration configuration, IConsumerRepository consumerRepository) 
        {
            _configuration = configuration;
            _consumerRepository = consumerRepository;
        }

        public IResult Generate(LoginDto login)
        {
            //TODO:
            //CONSULTAR USUARIO PARA AUTENTICAR

            CredentialEntity credentialEntity = new CredentialEntity(login.User);
           
            if (credentialEntity.Invalid || !_consumerRepository.Exists(long.Parse(login.User)))
            {
                return new ValidateResult(credentialEntity.Notifications, false, "Probleamas ao obter acesso");
            }
            
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new Claim(nameof(login.User), login.User)
            };
          
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                                             issuer: _configuration["Jwt:Issuer"],
                                             audience: _configuration["Jwt:Audience"],
                                             expires: DateTime.Now.AddMinutes(120),
                                             claims: claims,
                                             signingCredentials: signingCredentials);

            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
           
            return new ValidateResult(token, true, "Acesso permitido");
        }
    }
}
