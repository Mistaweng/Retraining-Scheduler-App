using Microsoft.Extensions.DependencyInjection;
using RetrainingSchedulerApp.Services;

namespace RetrainingSchedulerApp
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<SchedulerService>();
			services.AddSingleton<SchedulerManager>();
		}
	}
}
