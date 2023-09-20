using FileSharingSystem.Repository.DatabaseContext;
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
		}

		private static void ConfigureRepositories(IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<FileSharingSystemDbContext>(options => options.UseSqlServer(
			configuration.GetConnectionString("DefaultConnection")
			));
			// dodat ode sve scopove za repositorie
		}
	}
}
