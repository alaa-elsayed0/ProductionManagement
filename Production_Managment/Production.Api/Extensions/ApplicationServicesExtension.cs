using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Production.Api.Errors;
using Production.Core.Entities;
using Production.Core.Interface.Repositories;
using Production.Core.Interface.Service;
using Production.Reprository.Context;
using Production.Reprository.Repositories;
using Production.Services;
using System.Reflection;

namespace Production.Api.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("SQlConnection"));
            });


            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductPlanning, ProductPlanningService>();
            services.AddScoped<IProductOperationService, ProductOperationService>();
            services.AddScoped<ITrackingService, TrackingService>();
            services.AddScoped<IStopRecordService, StopRecordService>();
            services.AddScoped<IGenericRepository<Product, int>, GenericRepository<Product, int>>();
            services.AddScoped<IGenericRepository<ProductPlanning, int>, GenericRepository<ProductPlanning, int>>();
            services.AddScoped<IGenericRepository<ProductionOperation, int>, GenericRepository<ProductionOperation, int>>();
            services.AddScoped<IGenericRepository<StopRecords, int>, GenericRepository<StopRecords, int>>();
            services.AddScoped<IGenericRepository<Tracking, int>, GenericRepository<Tracking, int>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Where(m => m.Value.Errors.Any()).SelectMany(m => m.Value.Errors).Select(e => e.ErrorMessage).ToList();

                    var response = new ApiValidationErrorResponse() { Errors = errors };
                    return new BadRequestObjectResult(response);
                };
            });
            return services;
        }
    }
}
