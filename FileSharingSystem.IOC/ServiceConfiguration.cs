using AutoMapper;
using FileSharingSystem.Contract;
using FileSharingSystem.DAL.DatabaseContext;
using FileSharingSystem.DAL.Repository;
using FileSharingSystem.DTO;
using FileSharingSystem.Service;
using FileSharingSystem.Service.Mapping;
using FileSharingSystem.Service.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingSystem.IOC
{
	public static class ServiceConfiguration
	{
		public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
		{
			ConfigureRepositories(services, configuration);
			ConfigureApplicationServices(services, configuration);
			ConfigureAuthentication(services, configuration);
			ConfigureFluentValidation(services, configuration);
		}
		public static void ConfigureLogging(this IServiceCollection services, WebApplicationBuilder builder)
		{
			builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
		}


		private static void ConfigureAuthentication(IServiceCollection services, IConfiguration configuration)
		{
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(o =>
			{
				o.TokenValidationParameters = new TokenValidationParameters
				{
					ValidIssuer = configuration["Jwt:Issuer"],
					ValidAudience = configuration["Jwt:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey
					(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true
				};
			});
			services.AddAuthorization();
		}

		private static void ConfigureRepositories(IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<FileSharingSystemDbContext>(options => options.UseSqlServer(
			configuration.GetConnectionString("DefaultConnection")
			));
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IAuthRepository, AuthRepository>();
		}

		private static void ConfigureApplicationServices(IServiceCollection services, IConfiguration configuration)
		{
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new UserProfile());
			});
			services.AddSingleton(mappingConfig.CreateMapper());

			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IAuthService, AuthService>();
			services.AddScoped<IHashService, HashService>();
		}

		private static void ConfigureFluentValidation(IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<IValidator<AddUserRequest>, UserValidator>();
		}
	}
}
