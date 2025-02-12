using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using TaskManagement.API.Extensions;
using TaskManagement.Infrastructure.Context;
using TaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TaskManagement.API.Middlewares;
using TaskManagement.Application.Options;

var builder = WebApplication.CreateBuilder(args);
IHostEnvironment env = builder.Environment;
var appSettings = env.IsDevelopment() ? "appsettings.Development.json" : "appsettings.json";
builder.Configuration
    .AddJsonFile($"{appSettings}", true, true);


builder.Services.Configure<FrontEndHost>(
    builder.Configuration.GetSection(
        key: nameof(FrontEndHost))); //ovaj key nameof frontendhost mora bit isto kao tamo u app settings

builder.Services.Configure<Jwt>(
    builder.Configuration.GetSection(
        key: nameof(Jwt)));

var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<TMContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddIdentity<User, Role>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<TMContext>()
    .AddDefaultTokenProviders();

// Adding Authentication
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })

// Adding Jwt Bearer
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:ValidAudience"],
            ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
        };
    });


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:8080") 
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});
builder.Services.AddServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddLogging();
builder.Services.AddExceptionHandler<ExceptionHandlingMiddleware>();
builder.Services.AddBrevoService(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    //replace DataContext with your Db Context name
    var dataContext = scope.ServiceProvider.GetRequiredService<TMContext>();
    dataContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();


    //app.UseSwagger();
    //app.UseSwaggerUI(c =>
    //{
    //    c.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");
    //});
}
else
{
    app.UseHsts();
   // app.UseHttpsRedirection();
}

//app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.MapOpenApi();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); 

app.UseAuthentication();
app.UseAuthorization();
app.Run();


