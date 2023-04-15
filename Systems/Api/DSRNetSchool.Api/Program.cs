//using DSRNetSchool.Api;
//using DSRNetSchool.Api.Configuration;
//using DSRNetSchool.Context;
//using DSRNetSchool.Services.Settings;
//using DSRNetSchool.Settings;

//var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//var mainSettings = Settings.Load<MainSettings>("Main");
//var identitySettings = Settings.Load<IdentitySettings>("Identity");
//var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");

//builder.AddAppLogger();

// Configure services 
//var services = builder.Services;

//services.AddHttpContextAccessor();
//services.AddAppCors(); 

//services.AddAppDbContext(builder.Configuration);
//services.AddAppAuth(identitySettings);

//services.AddAppHealthChecks();
//services.AddAppVersioning();
//services.AddAppSwagger(identitySettings, swaggerSettings);
//services.AddAppAutoMappers();

//services.AddAppControllerAndViews();

//services.RegisterAppServices();

//builder.Services.AddControllers(); убрал, тк на Workshop 1 1:16:48 без этого, а через services.AddAppContr..

//var app = builder.Build();
//app.UseStaticFiles();

//app.UseAppHealthChecks();
//app.UseAppSwagger();



// Configure the HTTP request pipeline.


//app.UseAppAuth();

//app.UseAppControllerAndViews();

//app.UseAppMiddlewares();
///*app.UseAuthorization();

//app.MapControllers(); Закомментировал, тк авторизация и маппер будет потом*/

//DbInitializer.Execute(app.Services);
//DbSeeder.Execute(app.Services, true, true);

//app.Run();


using DSRNetSchool.Api;
using DSRNetSchool.Api.Configuration;
using DSRNetSchool.Context;
using DSRNetSchool.Services.Settings;
using DSRNetSchool.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var mainSettings = Settings.Load<MainSettings>("Main");
var identitySettings = Settings.Load<IdentitySettings>("Identity");
var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");

builder.AddAppLogger();

// Configure services
var services = builder.Services;

services.AddHttpContextAccessor();
services.AddAppCors();

services.AddAppDbContext(builder.Configuration);
services.AddAppAuth(identitySettings);

services.AddAppHealthChecks();
services.AddAppVersioning();
services.AddAppSwagger(identitySettings, swaggerSettings);
services.AddAppAutoMappers();

services.AddAppControllerAndViews();

services.RegisterAppServices();



// Configure the HTTP request pipeline.

var app = builder.Build();

//app.UseAppCors();

app.UseAppHealthChecks();

app.UseAppSwagger();

app.UseAppAuth();

app.UseAppControllerAndViews();

app.UseAppMiddlewares();


DbInitializer.Execute(app.Services);
DbSeeder.Execute(app.Services, true, true);

app.Run();

