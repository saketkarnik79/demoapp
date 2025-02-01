using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using MassTransit;
using OrderService.Messaging;
//using Azure.Messaging.ServiceBus;

namespace OrderService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Order Service starting...");
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<OrderDbContext>(options =>
            {
                options.UseInMemoryDatabase("OrderDb");
            });
            builder.Services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq://rabbitmq");
                });
            });

            builder.Services.AddScoped<OrderPublisher>();

            //builder.Services.AddSingleton(_ =>
            //    new ServiceBusClient(builder.Configuration.GetConnectionString("sbcs")
            //));
            //builder.Services.AddScoped<OrderPublisher>(options=>
            //    new OrderPublisher(options.GetRequiredService<ServiceBusClient>(), "ordersq"));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
           // if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
