using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ThisIsMyProve.Core.IRepositories;
using ThisIsMyProve.Core.IServices;
using ThisIsMyProve.DataAccess;
using ThisIsMyProve.DataAccess.Repositories;
using ThisIsMyProve.Services.Services;
using ThisIsMyProve.Services.Validations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
    .AddFluentValidation(configurationExpression: x => x.RegisterValidatorsFromAssemblyContaining<ListSliderDtoValidation>());
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

string root = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Log\\";
#region Library Services and Settings

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<thisIsMyProveDbContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"),
        option =>
        {
            option.MigrationsAssembly(Assembly.GetAssembly(typeof(thisIsMyProveDbContext)).GetName().Name);
        }));
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddFile(root + @"\Prove_{0:yyyy}-{0:MM}-{0:dd}.log", fileLoggerOpts =>
    {
        fileLoggerOpts.FormatLogFileName = fName =>
        {
            return String.Format(fName, DateTime.UtcNow);
        };
    });
});

#endregion
#region Ioc Settings

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped(typeof(ISliderRepository), typeof(SliderRepository));
builder.Services.AddScoped(typeof(ISliderService), typeof(SliderService));

#endregion


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
