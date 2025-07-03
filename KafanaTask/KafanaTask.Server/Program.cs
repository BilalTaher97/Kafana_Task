using KafanaTask.Repository.Implemetnation;
using KafanaTask.Repository.Interface;
using KafanaTask.Server.Models;
using KafanaTask.Server.Repository.Implementation;
using KafanaTask.Server.Repository.Interface;
using KafanaTask.Server.Service.Implementation;
using KafanaTask.Server.Service.Interface;
using KafanaTask.Service.Implemetnation;
using KafanaTask.Service.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("YourConnectionString")));


builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped<IAdminProductsService, AdminProductsService>();
builder.Services.AddScoped<IAdminProductsRepo, AdminProductsRepo>();

builder.Services.AddScoped<IAdminOrdersRepos, AdminOrdersRepos>();
builder.Services.AddScoped<IAdminOrdersService, AdminOrdersService>();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
            .AllowAnyOrigin()    
            .AllowAnyHeader()  
            .AllowAnyMethod();   
    });
});





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");
app.UseAuthorization();




app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
