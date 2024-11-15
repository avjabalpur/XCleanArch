using Microsoft.Extensions.DependencyInjection;
using XcdifyConnect.Application.Interfaces;
using XcdifyConnect.Application.Services;
using XcdifyConnect.Domain.Services;

namespace XcdifyConnect.Application
{
	public static class Startup
	{
		public static void AddApplicationLayer(this IServiceCollection services)
		{
			// Register application services
			
			services.AddScoped<ICallRecordService, CallRecordService>();
			services.AddScoped<IUserService, UserService>();
		}
	}
}
