using MessageNoteManager.BusinessLogic;
using MessageNoteManager.BusinessLogic.Interface;
using MessageNoteManager.DataAccess;
using MessageNoteManager.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using MessageNoteManager.WebAPI.OpenApiSecurity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DbContext, MessageNoteManagerContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<ILoginLogic, LoginLogic>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();

builder.Services.AddScoped<IUserLogic, UserLogic>();
builder.Services.AddScoped<IMessageLogic, MessageLogic>();
builder.Services.AddScoped<INoteLogic, NoteLogic>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}/";
    options.Audience = builder.Configuration["Auth0:Audience"];
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("User", policy =>
                      policy.RequireClaim("permissions", "user:messages")
                      .RequireClaim("permissions", "user:notes"));
    options.AddPolicy("Admin", policy =>
                      policy.RequireClaim("permissions", "admin:messages")
                      .RequireClaim("permissions", "admin:notes"));
    options.AddPolicy("SuperAdmin", policy =>
                      policy.RequireClaim("permissions", "admin:users"));
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MessageNoteManager", Version = "v1.0.0" });

    string securityDefinitionName = builder.Configuration["SwaggerUISecurityMode"] ?? "Bearer";
    OpenApiSecurityScheme securityScheme = new OpenApiBearerSecurityScheme();
    OpenApiSecurityRequirement securityRequirement = new OpenApiBearerSecurityRequirement(securityScheme);

    if (securityDefinitionName.ToLower() == "oauth2")
    {
        securityScheme = new OpenApiOAuthSecurityScheme(builder.Configuration["Auth0:Domain"], builder.Configuration["Auth0:Audience"]);
        securityRequirement = new OpenApiOAuthSecurityRequirement();
    }

    c.AddSecurityDefinition(securityDefinitionName, securityScheme);

    c.AddSecurityRequirement(securityRequirement);
});

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        if (builder.Configuration["SwaggerUISecurityMode"]?.ToLower() == "oauth2")
        {
            c.OAuthClientId(builder.Configuration["Auth0:ClientId"]);
            c.OAuthClientSecret(builder.Configuration["Auth0:ClientSecret"]);
            c.OAuthAppName("MessageNoteManagerApp");
            c.OAuthAdditionalQueryStringParams(new Dictionary<string, string> { { "audience", builder.Configuration["Auth0:Audience"] } });
            c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
