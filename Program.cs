using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using FleskBtocBackend.Data;
using FleskBtocBackend.Models;
using FleskBtocBackend.Services;  // Ensure this namespace is included
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using FleskBtocBackend.Repositories;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FleskBtoc API", Version = "v1" });
});

// Configure Entity Framework and Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Ensure DefaultConnection is defined in appsettings.json

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Register custom services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

// Configure JWT Authentication
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT key is not configured"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

// Configure CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FleskBtoc API v1"));
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

SeedDatabase(app.Services);

app.Run();

// Method to seed the database
void SeedDatabase(IServiceProvider serviceProvider)
{
    using (var scope = serviceProvider.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        // Clear existing data
        if (context.Categories.Any())
        {
            context.Categories.RemoveRange(context.Categories);
            context.SaveChanges();
        }

        if (context.Products.Any())
        {
            context.Products.RemoveRange(context.Products);
            context.SaveChanges();
        }

        // Add new data
        var categories = new List<Category>
        {
            new Category { name = "Electronics" },
            new Category { name = "Phones" },
            new Category { name = "Informatique" },
            new Category { name = "Mode" }
        };

        context.Categories.AddRange(categories);
        context.SaveChanges();

        var electronicsCategory = categories.First(c => c.name == "Electronics");
        var phonesCategory = categories.First(c => c.name == "Phones");
        var informatiqueCategory = categories.First(c => c.name == "Informatique");
        var modeCategory = categories.First(c => c.name == "Mode");

        var products = new List<Product>
        {
            new Product { title = "Smart TV", price = 499.99M, CategoryId = electronicsCategory.id, imageUrl = "assets/images/Electronics/TV-LG1.png", description = "High-definition smart TV", quantity = 10 },
            new Product { title = "Washing Machine", price = 899M, CategoryId = electronicsCategory.id, imageUrl = "assets/images/Electronics/washing_machine_samsung_1.png", description = "High-efficiency machine", quantity = 5 },
            new Product { title = "Another TV", price = 599.99M, CategoryId = electronicsCategory.id, imageUrl = "assets/images/Electronics/AnotherTV.png", description = "4K Ultra HD TV", quantity = 8 },
            new Product { title = "Smartphone", price = 299.99M, CategoryId = phonesCategory.id, imageUrl = "assets/images/Phones/portable-samsung-galaxy-a05s_1.png", description = "Latest model smartphone", quantity = 15 },
            new Product { title = "Laptop", price = 899.99M, CategoryId = informatiqueCategory.id, imageUrl = "assets/images/Electronics/Laptop.png", description = "High-performance laptop", quantity = 5 },
            new Product { title = "Gaming Laptop", price = 1299.99M, CategoryId = informatiqueCategory.id, imageUrl = "assets/images/Electronics/GamingLaptop.png", description = "High-end gaming laptop", quantity = 3 },
            new Product { title = "Jeans", price = 49.99M, CategoryId = modeCategory.id, imageUrl = "assets/images/Fashion/Jeans.png", description = "Comfortable jeans", quantity = 20 },
            new Product { title = "Jacket", price = 79.99M, CategoryId = modeCategory.id, imageUrl = "assets/images/Fashion/Jacket.png", description = "Stylish jacket", quantity = 12 }
        };

        context.Products.AddRange(products);
        context.SaveChanges();
    }
}
