using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RetrainingSchedulerApp
{
	static class Program
	{
		static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			var schedulerManager = host.Services.GetRequiredService<SchedulerManager>();

			var sessions = schedulerManager.GetSessions();
			schedulerManager.ScheduleAndDisplayTracks(sessions);
		}

		static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureServices((_, services) =>
					new Startup().ConfigureServices(services));
	}
}
