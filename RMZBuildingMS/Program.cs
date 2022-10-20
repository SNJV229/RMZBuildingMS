using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RMZBuildingMS.Authentication;
using RMZBuildingMS.Models;
using RMZBuildingMS.Repository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


//Adding Authentication
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
//Adding Jwt Bearer

    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = false,
            ValidAudience = builder.Configuration["JWT: ValidAudience"],
            ValidIssuer = builder.Configuration["JWT: ValidateIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),

        };
    });

builder.Services.AddAuthorization();

// Add services to the container.
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddControllers();

//Adding Entity Framework
var connectionString = builder.Configuration.GetConnectionString("RMZBuilderDB");
builder.Services.AddDbContext<RMZContext>(options => options.UseNpgsql(connectionString));

var connectionString2 = builder.Configuration.GetConnectionString("AuthenticationDB");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString2));

//Adding Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IGetInfo, GetInfo>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseAuthorization();
app.UseAuthentication();

app.Run();
