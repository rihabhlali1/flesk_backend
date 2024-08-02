using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using FleskBtocBackend.Data;
using FleskBtocBackend.Models;
using FleskBtocBackend.Services;
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
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

// Seed the database
SeedDatabase(app.Services);

app.Run();

// Method to seed the database
void SeedDatabase(IServiceProvider serviceProvider)
{
    using (var scope = serviceProvider.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        // Ensure database is created
        context.Database.EnsureCreated();

        // Add or retrieve categories
        var electronicsCategory = GetOrCreateCategory(context, "Electronics");
        var phonesCategory = GetOrCreateCategory(context, "Phones");
        var informatiqueCategory = GetOrCreateCategory(context, "Informatique");
        var modeCategory = GetOrCreateCategory(context, "Mode");

        // Clear existing data
        context.Products.RemoveRange(context.Products);
        context.SaveChanges();

        // Add new products
        AddProducts(context, electronicsCategory, GetElectronicsProducts());
        AddProducts(context, phonesCategory, GetPhonesProducts());
        AddProducts(context, informatiqueCategory, GetInformatiqueProducts());
        AddProducts(context, modeCategory, GetModeProducts());

        context.SaveChanges();
    }
}

// Method to get or create a category
Category GetOrCreateCategory(ApplicationDbContext context, string categoryName)
{
    var category = context.Categories.FirstOrDefault(c => c.name == categoryName);
    if (category == null)
    {
        category = new Category { name = categoryName };
        context.Categories.Add(category);
        context.SaveChanges();
    }
    return category;
}

// Method to add products for a given category
void AddProducts(ApplicationDbContext context, Category category, List<Product> products)
{
    foreach (var product in products)
    {
        if (!context.Products.Any(p => p.sku == product.sku)) // Check for existing product by SKU
        {
            product.categoryId = category.id;
            context.Products.Add(product);
        }
    }
}

// Define predefined products for Electronics
List<Product> GetElectronicsProducts()
{
    return new List<Product>
    {
        new Product
        {
            title = "Smart TV 55\" 4K",
            price = 799.99m,
            description = "Ultra HD Smart TV with 4K resolution and smart features.",
            imageUrl = "assets/images/Electronics/TV-1.png",
            images = new List<string> 
            {
                "assets/images/Electronics/TV-1.png",
                "assets/images/Electronics/TV-2.png",
                "assets/images/Electronics/TV-3.png"
            },
            quantity = 50,
            features = "4K resolution, Smart TV, HDR",
            longDescription = "A 55-inch Ultra HD Smart TV with 4K resolution, offering crisp and vibrant visuals.",
            highlights = "4K resolution, Smart features, HDR",
            performance = "High performance with low latency",
            battery = "N/A",
            security = "N/A",
            screen = "55 inches",
            resolution = "3840 x 2160",
            processor = "Quad-core",
            ram = "2 GB",
            storage = "16 GB",
            frontCamera = "N/A",
            rearCamera = "N/A",
            sim = "N/A",
            os = "Android TV",
            connectivity = "Wi-Fi, Bluetooth, HDMI",
            sku = "TV-55-4K",
            gtin = "1234567890123",
            range = "Electronics",
            model = "TV-2024",
            weight = "15.0 kg",
            color = "Black",
            shippingDiscount = 50.00m,
            shippingDestination = "Tunisia",
            newCustomerDiscount = 10.0m,
            newCustomerCode = "NEW10",
            newCustomerLimit = 100.0m,
            contactNumber = "+21612345678",
            freeShippingThreshold = 200.0m,
            express = true,
            rating = 4.5m,
            reviewsCount = 150
        }

        
    };
}

// Define predefined products for Phones
List<Product> GetPhonesProducts()
{
    return new List<Product>
    {
        new Product
        {
            title = "Samsung Galaxy S21",
            price = 999.99m,
            description = "Latest Samsung Galaxy with high-end specs.",
            imageUrl = "assets/images/Phones/Smartphone-1.png",
            images = new List<string> 
            {
                "assets/images/Phones/Smartphone-1.png",
                "assets/images/Phones/Smartphone-2.png",
                "assets/images/Phones/Smartphone-3.png"
            },
            quantity = 100,
            features = "High-end specs, 5G support",
            longDescription = "Samsung Galaxy S21 offers cutting-edge technology and high performance.",
            highlights = "5G connectivity, High-resolution camera",
            performance = "High performance with Exynos 2100",
            battery = "4000 mAh",
            security = "Fingerprint scanner, Facial recognition",
            screen = "6.2 inches",
            resolution = "2400 x 1080",
            processor = "Exynos 2100",
            stock = 10,
            ram = "8 GB",
            storage = "128 GB",
            frontCamera = "10 MP",
            rearCamera = "64 MP Triple camera",
            sim = "Dual SIM",
            os = "Android 11",
            connectivity = "5G, Wi-Fi, Bluetooth",
            sku = "S21-128GB",
            gtin = "9876543210123",
            range = "Phones",
            model = "S21-2024",
            weight = "169.0 g",
            color = "Phantom Gray",
            shippingDiscount = 100.00m,
            shippingDestination = "Tunisia",
            newCustomerDiscount = 15.0m,
            newCustomerCode = "NEW15",
            newCustomerLimit = 150.0m,
            contactNumber = "+21623456789",
            freeShippingThreshold = 250.0m,
            express = false,
            rating = 4.7m,
            reviewsCount = 200
        }
        // Add more predefined products here...
    };
}

// Define predefined products for Informatique
List<Product> GetInformatiqueProducts()
{
    return new List<Product>
    {
        new Product
        {
            title = "Laptop ASUS ROG",
            price = 1499.99m,
            description = "High-performance gaming laptop from ASUS ROG series.",
            imageUrl = "assets/images/Informatique/laptop-asus-rog.png",
            images = new List<string> 
            {
                "assets/images/Informatique/laptop-asus-rog-1.png",
                "assets/images/Informatique/laptop-asus-rog-2.png",
                "assets/images/Informatique/laptop-asus-rog-3.png"
            },
            quantity = 30,
            features = "High performance, RGB lighting",
            longDescription = "ASUS ROG gaming laptop with high-end specs for serious gamers.",
            highlights = "Powerful GPU, High-refresh-rate screen",
            performance = "Exceptional gaming performance",
            battery = "70 WHr",
            security = "Fingerprint sensor",
            screen = "15.6 inches",
            resolution = "1920 x 1080",
            processor = "Intel Core i9",
            ram = "32 GB",
            storage = "1 TB SSD",
            frontCamera = "720p HD",
            rearCamera = "N/A",
            sim = "N/A",
            os = "Windows 11",
            connectivity = "Wi-Fi 6, Bluetooth 5.1",
            sku = "ROG-2024",
            gtin = "2345678901234",
            range = "Informatique",
            model = "G15-2024",
            weight = "2.5 kg",
            color = "Black",
            shippingDiscount = 200.00m,
            shippingDestination = "Tunisia",
            newCustomerDiscount = 20.0m,
            newCustomerCode = "NEW20",
            newCustomerLimit = 200.0m,
            contactNumber = "+21634567890",
            freeShippingThreshold = 300.0m,
            express = true,
            rating = 4.8m,
            reviewsCount = 100
        }
        // Add more predefined products here...
    };
}

// Define predefined products for Mode
List<Product> GetModeProducts()
{
    return new List<Product>
    {
        new Product
        {
            title = "Designer Handbag",
            price = 199.99m,
            description = "Luxury designer handbag with elegant design.",
            imageUrl = "assets/images/Mode/Handbag-1.png",
            images = new List<string> 
            {
                "assets/images/Mode/Handbag-1.png",
                "assets/images/Mode/Handbag-2.png",
                "assets/images/Mode/Handbag-3.png"
            },
            quantity = 20,
            features = "Elegant design, Premium materials",
            longDescription = "Luxury handbag crafted with attention to detail, perfect for any occasion.",
            highlights = "Designer brand, Premium quality",
            performance = "Durable and stylish",
            battery = "N/A",
            security = "N/A",
            screen = "N/A",
            resolution = "N/A",
            processor = "N/A",
            ram = "N/A",
            storage = "N/A",
            frontCamera = "N/A",
            rearCamera = "N/A",
            sim = "N/A",
            os = "N/A",
            connectivity = "N/A",
            sku = "HB-2024",
            gtin = "3456789012345",
            range = "Mode",
            model = "HB-LUX",
            weight = "0.5 kg",
            color = "Red",
            shippingDiscount = 50.00m,
            shippingDestination = "Tunisia",
            newCustomerDiscount = 5.0m,
            newCustomerCode = "NEW5",
            newCustomerLimit = 50.0m,
            contactNumber = "+21645678901",
            freeShippingThreshold = 100.0m,
            express = false,
            rating = 4.3m,
            reviewsCount = 75
        }
        // Add more predefined products here...
    };
}
