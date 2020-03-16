namespace RolePlayingGame.Server
{
	using System.IO;
	using System.Threading.Tasks;

	using Microsoft.AspNetCore;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.Configuration;

	public class Program
	{
		public static async Task Main(string[] args) => await BuildWebHost(args).RunAsync();

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder<Startup>(args)
				.ConfigureAppConfiguration((context, configuration) => configuration
					.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonStream(new FileStream("appsettings.json", FileMode.Open))
					.AddJsonStream(new FileStream($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", FileMode.Open))
					.AddEnvironmentVariables()
					.AddCommandLine(args))
				.Build();
	}
}
