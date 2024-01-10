using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Helpers;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories;
using EmployeeManagementAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference= new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[] { }
        }
    });
});

// Db Connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("The connection is not found")));

// Dependency Injections
builder.Services.AddScoped<IUserAccount, UserAccountRepository>();

builder.Services.AddScoped<IGenericRepository<GeneralDepartment>, GeneralDepartmentRepository>();
builder.Services.AddScoped<IGenericRepository<Department>, DepartmentRepository>();
builder.Services.AddScoped<IGenericRepository<Branch>, BranchRepository>();


builder.Services.AddScoped<IGenericRepository<Country>, CountryRepository>();
builder.Services.AddScoped<IGenericRepository<City>, CityRepository>();
builder.Services.AddScoped<IGenericRepository<Town>, TownRepository>();

builder.Services.AddScoped<IGenericRepository<Employee>, EmployeeRepository>();

builder.Services.AddScoped<IGenericRepository<Overtime>, OvertimeRepository>();
builder.Services.AddScoped<IGenericRepository<OvertimeType>, OvertimeTypeRepository>();

builder.Services.AddScoped<IGenericRepository<Vacation>, VacationRepository>();
builder.Services.AddScoped<IGenericRepository<VacationType>, VacationTypeRepository>();

builder.Services.AddScoped<IGenericRepository<Sanction>, SanctionRepository>();
builder.Services.AddScoped<IGenericRepository<SanctionType>, SanctionTypeRepository>();

builder.Services.AddScoped<IGenericRepository<Doctor>, DoctorRepository>();


// Jwt Map
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
var jwtConfig = builder.Configuration.GetSection(nameof(JwtConfig)).Get<JwtConfig>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig!.Key!))
        };
    });

// Cors
builder.Services.AddCors(options =>
    options.AddPolicy("DefaultCors", builder =>
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors("DefaultCors");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
