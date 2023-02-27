using CoreService_backend.Configurations.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddMapper();
builder.AddAuthentication();

builder.ConfigureJwt();
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
