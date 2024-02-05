using Microsoft.EntityFrameworkCore;
using APIsrl.Data;
using APIsrl.Repository;
using APIsrl.Repository.Interfaces;
namespace APIsrl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configure the Database acess
            builder.Services.AddEntityFrameworkNpgsql()
                .AddDbContext<ContextDataBase>(
                    options => options.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
                );

            // Configures the Repository dependencies 
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
            builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();





            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
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
