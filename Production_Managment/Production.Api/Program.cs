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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("SQlConnection"));
});


builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductPlanning, ProductPlanningService>();
builder.Services.AddScoped<IProductOperationService, ProductOperationService>();
builder.Services.AddScoped<ITrackingService, TrackingService>();
builder.Services.AddScoped<IStopRecordService, StopRecordService>();
builder.Services.AddScoped<IGenericRepository<Product, int>, GenericRepository<Product, int>>();
builder.Services.AddScoped<IGenericRepository<ProductPlanning, int>, GenericRepository<ProductPlanning, int>>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState.Where(m => m.Value.Errors.Any()).SelectMany(m => m.Value.Errors).Select(e => e.ErrorMessage).ToList();

        var response = new ApiValidationErrorResponse() { Errors = errors };
        return new BadRequestObjectResult(response);
    };
});
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
