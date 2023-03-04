using FluentValidation.AspNetCore;
using Kuari.TodoApp.Core.Repositories;
using Kuari.TodoApp.Core.Services;
using Kuari.TodoApp.Core.UnitOfWork;
using Kuari.TodoApp.Repository.Contexts;
using Kuari.TodoApp.Repository.Repositories;
using Kuari.TodoApp.Repository.UnitOfWork;
using Kuari.TodoApp.Service.Services;
using Kuari.TodoApp.Service.Validations;
using Kuari.TodoApp.WebAPI.Filters;
using Kuari.TodoApp.WebAPI.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(options =>
    {
        options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
// FluentValidation
builder.Services.AddControllers(x =>
{
    x.Filters.Add(new ValidateFilterAttribute());
}).AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssemblyContaining<TodoCreateDtoValidator>();
});


builder.Services.Configure<ApiBehaviorOptions>(opt =>
{
    opt.SuppressModelStateInvalidFilter = true;
});





builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IService<,,,>), typeof(Service<,,,>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<TodoAppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(TodoAppDbContext)).GetName().Name);
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
