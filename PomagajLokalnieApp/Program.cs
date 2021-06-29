using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PomagajLokalnieApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await ConfigureDatabase(host);
            await host.RunAsync();
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        
        public static async Task ConfigureDatabase(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<IAppDbContext>();
            await context.Database.EnsureCreatedAsync();
        }
    }
}