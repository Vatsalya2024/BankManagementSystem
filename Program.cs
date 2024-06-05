using BOOKSTORE.Data;
using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;
using BOOKSTORE.Repository;
using BOOKSTORE.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<BookStoreDBContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnectionString"));
    });

//Services for Repositories
builder.Services.AddScoped<IRepository<int, Book>, BookRepository>();
builder.Services.AddScoped<IRepository<int, BookCategory>, BookCategoryRepository>();
builder.Services.AddScoped<IRepository<int, CartItem>, CartItemRepository>();
builder.Services.AddScoped<IRepository<int, Category>, CategoryRepository>();
builder.Services.AddScoped<IRepository<int, Order>, OrderRepository>();
builder.Services.AddScoped<IRepository<int, OrderItem>, OrderItemRepository>();
builder.Services.AddScoped<IRepository<int, Review>, ReviewRepository>();
builder.Services.AddScoped<IRepository<int, User>, UserRepository>();

builder.Services.AddScoped<IBookService,BookService >();

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
