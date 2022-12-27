using BookStoreAPI.Services.IServices;
using BookStoreAPI.Services.Services;
using BookStoreAPI.DATA.Reponsitories.IR;
using BookStoreAPI.DATA.Reponsitories.Repon;
using BookStoreAPI.DATA;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using BookStoreAPI.DTO.Email;

var MyAllowSpecificOrigins = "CorsPolicy";
var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var connectionString = builder.Configuration.GetConnectionString("Default");
var emailConfig = builder.Configuration
        .GetSection("EmailConfiguration")
        .Get<EmailConfiguration>();

// Add services to the container.
services.AddCors(o =>
{
    o.AddPolicy(name: MyAllowSpecificOrigins, builder =>
    {
        builder.WithOrigins("http://localhost:3000", "https://hikarushop.vercel.app")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
services.AddSingleton(emailConfig);
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Swagger BookStore",
        Version = "v1",
        Description = "An ASP.NET Core Web API for managing BookStore By Nguyen Tan Sy, Tran Van Toan, Duong Dinh Thanh, Nguyen Trong Duc, Sisanonh Thinnakone",
        Contact = new OpenApiContact
        {
            Name = "Trần Văn Toàn",
            Url = new Uri("https://www.facebook.com/toantran932001")
        },
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                Enter 'Bearer' [space] and then your token in the text input below.
                \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
        {
            new OpenApiSecurityScheme
            {
            Reference = new OpenApiReference
                {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
            }
        });
});
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"]))
        };
    });
services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
services.AddScoped<ITokenService, TokenService>();
services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));
services.AddScoped<IUserReponsitory, UserReponsitory>();
services.AddScoped<ICartReponsitory, CartReponsitory>();
services.AddScoped<IOrderReponsitory, OrderReponsitory>();
services.AddScoped<IProductReponsitory, ProductReponsitory>();
services.AddScoped<IAuthService, AuthService>();
services.AddScoped<IProductService, ProductService>();
services.AddScoped<ICartService, CartService>();
services.AddScoped<IOrderService, OrderService>();
services.AddScoped<IVnpayServices, VnpayServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
