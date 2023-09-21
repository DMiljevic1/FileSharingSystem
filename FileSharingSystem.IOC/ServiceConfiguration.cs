using AutoMapper;
using FileSharingSystem.DAL.DatabaseContext;
using FileSharingSystem.Service.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
		}

		private static void ConfigureRepositories(IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<FileSharingSystemDbContext>(options => options.UseSqlServer(
			configuration.GetConnectionString("DefaultConnection")
			));
			// dodat ode sve scopove za repositorie
		}

		private static void ConfigureApplicationServices(IServiceCollection services, IConfiguration configuration)
		{
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new UserProfile());
			});
			services.AddSingleton(mappingConfig.CreateMapper());
		}
	}
}
