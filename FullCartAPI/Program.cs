using FullCartApp.Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = " API ", Version = "v1" });
    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    c.AddSecurityDefinition("Bearer", securitySchema);

    var securityRequirement = new OpenApiSecurityRequirement();
    securityRequirement.Add(securitySchema, new[] { "Bearer" });
    c.AddSecurityRequirement(securityRequirement);
});



FullCartApp.CompositionRoot.ServiceProvider.BuildServiceProvider(builder.Configuration, builder.Services);

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<dbContext>().AddDefaultTokenProviders();



//token Jwt
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


})
.AddJwtBearer(x =>
{
x.SaveToken = true;
x.RequireHttpsMetadata = true;
x.TokenValidationParameters = new TokenValidationParameters()
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidAudience = builder.Configuration["Jwt:Site"],
    ValidIssuer = builder.Configuration["Jwt:Site"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SigningKey"]))
};


x.Events = new JwtBearerEvents

{
    OnMessageReceived = context =>
    {
        var accessToken = context.Request.Query["access_token"];
        if (string.IsNullOrEmpty(accessToken) == false)
        {
            context.Token = accessToken;
        }
        return Task.CompletedTask;
    }
};
});


builder.Services.AddCors(options =>
           options.AddPolicy("AllowOrigin",
           builder =>
           {
               builder
                   // .AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials()

                  .WithOrigins(
                   "https://localhost:4200",
                  "http://localhost:4200"

                  );
           }));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigin");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// MigrateDB
using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        await   FullCartApp.CompositionRoot.ServiceProvider.MigrateDBAsync(app.Configuration, services);
    }


app.Run();



