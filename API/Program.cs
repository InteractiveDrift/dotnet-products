using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

// using ProductsContext context = new();

// var seeder = new DataSeeder(context);
// seeder.SeedProductGroupsFromCsv("Data/products/Products-product-groups.csv");
// seeder.SeedProducersFromCsv("Data/products/Products-producers.csv");
// seeder.SeedSuppliersFromCsv("Data/products/Products-suppliers.csv");
// seeder.SeedProductsFromCsv("Data/products/Products-products.csv");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProductsContext>(x => x.UseSqlite(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();

app.Run();