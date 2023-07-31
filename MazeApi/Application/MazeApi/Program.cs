using MazeGeneratorLib;
using MazeGeneratorLib.V2;

namespace MazeApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                //.AddAppDbContext(builder.Configuration.GetValue<string>("ConnectionString"))
                .AddScoped<IGenerator, MazeGenV2>()
                .AddCors();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.UseCors(builder => builder
               .SetIsOriginAllowed(orign => true)
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials());

            app.Run();
        }
    }
}