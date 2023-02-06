using DSRNetSchool.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddAppLogger();

// Configure services 
var services = builder.Services;

services.AddHttpContextAccessor();
services.AddAppCors(); 

services.AddAppHealthChecks();
services.AddAppVersioning();
services.AddAppSwagger();

services.AddAppControllerAndViews();

//builder.Services.AddControllers(); убрал, тк на Workshop 1 1:16:48 без этого, а через services.AddAppContr..

var app = builder.Build();

app.UseAppHealthChecks();
app.UseAppSwagger();

// Configure the HTTP request pipeline.

app.UseAppControllerAndViews();

/*app.UseAuthorization();

app.MapControllers(); «акомментировал, тк авторизаци€ будет потом*/ 

app.Run();
