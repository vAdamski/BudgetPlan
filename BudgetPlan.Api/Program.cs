using System.IdentityModel.Tokens.Jwt;
using BudgetPlan.Api.Services;
using BudgetPlan.Application;
using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Infrastructure;
using BudgetPlan.Persistence;
using IdentityModel;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddPersistence();
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.TryAddScoped(typeof(ICurrentUserService), typeof(CurrentUserService));

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:5001";
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            NameClaimType = JwtClaimTypes.Name,
            RoleClaimType = JwtClaimTypes.Role
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "api1");
    });
    options.AddPolicy("admin", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "api1");
        policy.RequireRole("admin");
    });
});

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            AuthorizationCode = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri("https://localhost:5001/connect/authorize"),
                TokenUrl = new Uri("https://localhost:5001/connect/token"),
                Scopes = new Dictionary<string, string>
                {
                    { "api1", "Full access" },
                    { "user", "User info" },
                    { "openid", "openid" },
                    { "role", "User role" },
                    { "IdentityServerApi" , "Identity Server Api Access"},
                    { "firstName", "First Name" },
                    { "lastName", "Last Name" }
                }
            }
        }
    });
    options.OperationFilter<AuthorizeCheckOperationFilter>();
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BudgetPlan",
        Version = "v1",
        Description = "",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Adam Ludwiczak",
            Email = ""
        },
        License = new OpenApiLicense
        {
            Name = "Used License",
            Url = new Uri("https://example.com/license")
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS", policy => policy.WithOrigins(
            "https://localhost:5001",
            "https://localhost:6001",
            "https://localhost:7001"
        )
        .AllowAnyHeader()
        .AllowAnyMethod());
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "");
    options.OAuthClientId("swagger");
    options.OAuthClientSecret("secret");
    options.OAuthUsePkce();
});

app.UseHttpsRedirection();

app.UseCors("CORS");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();