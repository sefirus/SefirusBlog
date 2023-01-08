using System.Text.Json.Serialization;
using DataAccess;
using Host.Middleware;
using Microsoft.EntityFrameworkCore;
using WebApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers(options =>
    {
        options.SuppressAsyncSuffixInActionNames = false;
    })
    .AddJsonOptions(jsonOptions =>
    {
        jsonOptions.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    })
    .AddApplicationPart(typeof(UserController).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BlogDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", corsPolicyBuilder =>
{
    corsPolicyBuilder.WithOrigins("https://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

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
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();