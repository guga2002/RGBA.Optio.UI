using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Optio.Core.Data;
using Optio.Core.Interfaces;
using Optio.Core.Repositories;
using RGBA.Optio.Core.Entities;
using RGBA.Optio.Core.Interfaces;
using RGBA.Optio.Core.PerformanceImprovmentServices;
using RGBA.Optio.Core.Repositories;
using RGBA.Optio.Domain.Interfaces;
using RGBA.Optio.Domain.LoggerFiles;
using RGBA.Optio.Domain.Mapper;
using RGBA.Optio.Domain.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<RoleManager<IdentityRole>>();
builder.Services.AddScoped<UserManager<User>>();
builder.Services.AddScoped<SignInManager<User>>();


builder.Services.AddScoped<ICategoryRepo, CategoryOfTransactionRepos>();
builder.Services.AddScoped<IChannelRepo, ChannelRepos>();
builder.Services.AddScoped<ILocationRepo, LocationRepos>();
builder.Services.AddScoped<IMerchantRepo, MerchantRepos>();
builder.Services.AddScoped<ITransactionRepo, TransactionRepos>();
builder.Services.AddScoped<ITypeOfTransactionRepo, TypeOfTransactionRepos>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUniteOfWork, UniteOfWork>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IStatisticService, StatisticService>();
builder.Services.AddScoped<ITransactionEventService, TransactionEventService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

builder.Services.AddSingleton<CacheService>();

builder.Services.AddMemoryCache();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddDbContext<OptioDB>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("OptiosString"));
});

builder.Services.AddIdentity<User, IdentityRole>().
    AddEntityFrameworkStores<OptioDB>().
    AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "http://localhost:42130",
            ValidAudience = "http://localhost:42130",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("65E255FF-F399-42D4-9C7F-D5D08B0EC285")),
        };
    });

builder.Logging.AddConsole();
builder.Logging.AddProvider(new LoggerProvider());
builder.Logging.SetMinimumLevel(LogLevel.Debug);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
