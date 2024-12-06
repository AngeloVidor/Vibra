using Microsoft.EntityFrameworkCore;
using Vibra.API.Controllers;
using Vibra.BLL.Interfaces;
using Vibra.BLL.Interfaces.Tokens;
using Vibra.BLL.Mapping;
using Vibra.BLL.Services;
using Vibra.BLL.Services.Tokens;
using Vibra.DAL.Context;
using Vibra.DAL.Interfaces;
using Vibra.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

//jwtConfiguration
builder
    .Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = Microsoft
            .AspNetCore
            .Authentication
            .JwtBearer
            .JwtBearerDefaults
            .AuthenticationScheme;
        options.DefaultChallengeScheme = Microsoft
            .AspNetCore
            .Authentication
            .JwtBearer
            .JwtBearerDefaults
            .AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters =
            new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
                    System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
                )
            };
    });

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IAddStandardUserRepository, AddStandardUserRepository>();
builder.Services.AddScoped<IAddStandardUserService, AddStandardUserService>();
builder.Services.AddScoped<ITokenManagementService, TokenManagementService>();


builder.Services.AddAutoMapper(typeof(MappingProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
