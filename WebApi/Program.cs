using Application;
using Identity;
using Identity.Seeds;
using Microsoft.AspNetCore.Identity;
using Persistence;
using Shared;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddApplicationLayer();
builder.Services.AddSharedInfraestructure();
builder.Services.AddIdentityInfraestructure(builder.Configuration);
builder.Services.AddPersistenceInfraestructure(builder.Configuration);
builder.Services.AddApiVersioningExtension();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
  //  var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
   // await DefaultAdminUser.SeedAsync(userManager);

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await DefaultRoles.SeedAsync(roleManager);
}


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseErrorHandlerMiddleware();
app.MapControllers();

app.Run();
