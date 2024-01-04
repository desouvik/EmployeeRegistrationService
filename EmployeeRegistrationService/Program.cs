using EmployeeRegistrationService.Data;
using EmployeeRegistrationService.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
//    .WriteTo("Logger/employeeRegistrationApi.log",RollingInterval: RollingInterval.Day).CreateLogger();

//builder.Host.UseSerilog();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//register respository classes into container
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
//register EF datacontext class with option
builder.Services.AddDbContext<DataContext>(option => { 
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")); 
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
