using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;
using NLog.Web;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<ICarRepository, CarRepository>();
builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<ILandlordRepository, LandlordRepository>();
builder.Services.AddTransient<ILandlordService, LandlordService>();
builder.Services.AddTransient<IModelRepository, ModelRepository>();
builder.Services.AddTransient<IModelService, ModelService>();
builder.Services.AddTransient<IRentingService, RentingService>();
builder.Services.AddTransient<IRentingRepository, RentingRepository>();



builder.Services.AddDbContext<CarRetalContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("school")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Host.UseNLog();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
//app.UseErrorHandlingMiddleware();
app.UseHttpsRedirection();  
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
//app.UseRatingMiddleware();
app.Run();




