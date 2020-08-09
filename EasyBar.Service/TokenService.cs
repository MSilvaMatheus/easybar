using EasyBar.Domain.Entity.Authentication;
using EasyBar.Domain.Entity.Validation;
using EasyBar.Domain.Interfaces;
using EasyBar.Domain.TransferObjects;
using EasyBar.Service.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace EasyBar.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public IResult Generate(LoginDto login)
        {
            CredentialEntity credentialEntity = new CredentialEntity(login.User, login.Password);
            var validateResult = credentialEntity.Validate(credentialEntity);

            if (!validateResult.IsValid)
            {
                return new ValidateResult(null, false, validateResult.ToString());
            }

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: _configuration["Jwt:Issuer"],
                                             audience: _configuration["Jwt:Audience"],
                                             expires: DateTime.Now.AddMinutes(120),
                                             signingCredentials: signingCredentials);

            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
           
            return new ValidateResult(token, true, string.Empty);
        }
    }
}
