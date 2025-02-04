using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddJsonFile("Ocelot.json");

            // Add services to the container.

            builder.Services.AddOcelot();
            builder.Services.AddAuthorization();

            var app = builder.Build();

            app.UseOcelot();
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.Run();
        }
    }
}
