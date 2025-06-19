using Microsoft.OpenApi.Models;
using System.Threading.RateLimiting;
using System.Security.Claims;
using Application.JWT;
using Application.Middlewares;
using Application.Dependency;
using Infrastracture.Data;
using Core;
using Application.ProgramConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(static swagger =>
{
    swagger.SwaggerDoc("admin", new OpenApiInfo { Title = "Admin API", Version = "v1" });
    swagger.SwaggerDoc("user", new OpenApiInfo { Title = "User API", Version = "v1" });

    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Attach JWT token in Bearer format 'Bearer {token}'"
    });

    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
   {
       {
           new OpenApiSecurityScheme
           {
               Reference = new OpenApiReference
               {
                   Type = ReferenceType.SecurityScheme,
                   Id = "Bearer"
               }
           },
           Array.Empty<string>()
       }
   });
});

builder.Services.AddProjects(builder.Configuration);

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

builder.Services.AddCoreServices();
builder.Services.AddAdminServices();
builder.Services.AddAnonymusServices();
builder.Services.AddUserServices();
builder.Services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));

builder.Services.AddCustomJwtBearer(builder.Configuration);

builder.Services.AddRateLimiter(r =>
{
    // Globlal rate limiter configuration
    r.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
    {
        var userId = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "anonymous";
        return RateLimitPartition.GetFixedWindowLimiter(userId, key => new FixedWindowRateLimiterOptions
        {
            PermitLimit = 50,
            Window = TimeSpan.FromMinutes(1),
            QueueLimit = 2,
        });
    });
});

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.  
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/admin/swagger.json", "Admin API v1");
        c.SwaggerEndpoint("/swagger/user/swagger.json", "User API v1");
    });
}

app.UseRateLimiter();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
