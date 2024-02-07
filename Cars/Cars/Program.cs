using FluentValidation.AspNetCore;
using FluentValidation;
using Cars.BL.Interfaces;
using Cars.BL.Services;
using Cars.DL.Interfaces;
using Cars.DL.Repositories;
using Cars.HealthChecks;


namespace Cars
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IMedicineRepository, ModelRepository>();
            builder.Services.AddSingleton<IManufacturerRepository, ManufacturerRepository>();

            builder.Services.AddSingleton<IMedicineService, MedicineService>();
            builder.Services.AddSingleton<IManufacturerService, ManufacturerService>();
            builder.Services.AddSingleton<IStoreService, StoreService>();

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));

            builder.Services.AddHealthChecks().AddCheck<CustomHealthCheck>(nameof(CustomHealthCheck));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.MapHealthChecks("/healthz");

            app.Run();
        }
    }
}