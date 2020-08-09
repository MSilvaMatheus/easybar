using EasyBar.Service.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EasyBar.Service.ConfigurationServices
{
    public static class ConfigurationService
    {
        public static void ContigurationJwt(this IServiceCollection service, IConfiguration configuration)
        {
			service.AddAuthentication
				(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = configuration["Jwt:Issuer"],
						ValidAudience = configuration["Jwt:Audience"],
						IssuerSigningKey = new SymmetricSecurityKey
					(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
					};
				});
		}

		public static void DependencyResolverService(this IServiceCollection service)
		{
			service.AddSingleton<ITokenService, TokenService>();
		}
    }
}
