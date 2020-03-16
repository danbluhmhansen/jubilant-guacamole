namespace RolePlayingGame.Client
{
	using System.Diagnostics.CodeAnalysis;
	using System.Threading.Tasks;

	using Blazored.LocalStorage;

	using Microsoft.AspNetCore.Blazor.Hosting;

	[SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "Static types cannot be used as type arguments.")]
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("app");

			builder.Services.AddBlazoredLocalStorage();

			await builder.Build().RunAsync();
		}
	}
}
