using API.Application.Mappers;
using API.Application.Services.Implementations;
using API.Application.Services.Interfaces;
using API.Domain.Entities;
using API.Domain.Repositories;
using API.Domain.Services;
using API.Infrastructure.Authentification;
using API.Infrastructure.Persistence;
using API.Infrastructure.Persistence.Repositories;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Database configuration
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration["ConnectionStrings:DefaultConnection"]));

// Authentification configuration
builder.Services
.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => // middleware JWT authentication
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["AuthConfiguration:Issuer"],
        ValidAudience = builder.Configuration["AuthConfiguration:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AuthConfiguration:Key"]
            ?? throw new InvalidOperationException("JWT key not configured")))
    };
});

// Mapster
builder.Services.AddMapster(); // IMapper
TypeAdapterConfig.GlobalSettings.Apply(new UserProfile());

// Others
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<UserDomainService>();

// Binding
builder.Services.Configure<AuthConfiguration>(
    builder.Configuration.GetSection("AuthConfiguration"));

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
