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
            builder.Services.AddCors(options => 
            { 
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            builder.Services.AddOcelot();
            builder.Services.AddAuthorization();

            var app = builder.Build();

            app.UseOcelot();
            app.UseCors("AllowAll");
            //app.UseHttpsRedirection();
            app.UseAuthorization();

            app.Run();
        }
    }
}
