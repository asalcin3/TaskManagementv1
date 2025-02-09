using TaskManagement.API.Extensions;
using TaskManagement.Infrastructure.Context;
using TaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<TMContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<TMContext>();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); 

app.UseAuthentication();
app.UseAuthorization();
app.Run();


