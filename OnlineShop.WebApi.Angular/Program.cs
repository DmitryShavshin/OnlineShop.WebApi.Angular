using Microsoft.EntityFrameworkCore;
using OnlineShop.WebApi.Angular.Data;
using OnlineShop.WebApi.Angular.Interfaces;
using OnlineShop.WebApi.Angular.Models;
using OnlineShop.WebApi.Angular.Services;
using OnlineShop.WebApi.Angular.Repository;
using OnlineShop.WebApi.Angular.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
}).AddIdentity<ApplicationUser, ApplicationRole>(config => {
    config.Password.RequireDigit = false;
    config.Password.RequireLowercase = false;
    config.Password.RequireUppercase = false;
    config.Password.RequireNonAlphanumeric = false;
    config.Password.RequiredLength = 6;
})
  .AddRoles<ApplicationRole>()
  .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddMvc();
builder.Services.AddMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => CartSevise.GetCart(sp));
builder.Services.AddTransient<IProduct, ProductRepository>();
builder.Services.AddTransient<ICategory, CategoryRepository>();
builder.Services.AddTransient<IBrand, BrandRepository>();
builder.Services.AddTransient<IOrder, OrderRepository>();
builder.Services.AddTransient<IUser, UserRepository>();



builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(jwt =>
{
    var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value);
    
    jwt.SaveToken = true;
    jwt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        RequireExpirationTime = false, // To do -- needs to be implement update generate tokens  
        ValidateLifetime = true
    };
});


// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(option =>
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options
    .AddPolicy(name: "OnlineShopOrigins", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
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

app.UseCors("OnlineShopOrigins");

app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.UseSession();
app.MapControllers();

app.Run();
