using LinkDev.OrderManagementSystem.Application;
using LinkDev.OrderManagementSystem.Infrastructure.Persistence;
using Microsoft.IdentityModel.Tokens;
using System.Text;



namespace LinkDev.OrderManagementSystem.APIs
{
    public class Program
    {

        // Entry Point
        public static async Task Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services

            // Add services to the container.

            builder.Services
                .AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            // builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddPresistenceServices(builder.Configuration);
            builder.Services.AddApplicationServices();


            #endregion

            var app = builder.Build();

            #region Databases Initialization 


            #endregion

            #region Configure Kestrel Middlewares

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                //app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers();

            #endregion

            app.Run();
        }
    }
}
