using CoreService_backend.Configurations.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


// W jaki sposób zmieniæ kolejnoœæ pobierania danych z ustawieñ? 
// Czy  builder.Configuration.AddUserSecrets<Program>(); jest potrzebny? 

//var secretsPath = Path.Combine(builder.Environment.ContentRootPath, ".config", "secrets.json");
//builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
//{
//    config.AddJsonFile("secrets.json", optional: true, reloadOnChange: true);
//    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
//    config.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
//    config.AddEnvironmentVariables();
//});

builder.ConfigureJwt();
builder.AddMapper();
builder.AddAuthentication();


builder.ConfigureIdentity();

builder.AddControllers();
builder.AddSwagger();
builder.AddPersistence();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();


var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

var app = builder.Build();// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(p => p.WithOrigins("http://localhost:5173")
    .AllowAnyHeader()
    .AllowAnyMethod());


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
