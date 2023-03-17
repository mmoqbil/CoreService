using CoreService_backend.Configurations.Extensions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.


//dlaczego nie dzia³a poprawnie kolejnoœæ pobierania configuracji? Nie pobiera danych z pliku secrets.json.

builder.AddMapper();

builder.ConfigureJwt();
builder.AddAuthentication();


builder.ConfigureIdentity();

builder.AddControllers();
builder.AddSwagger();
builder.AddPersistence();
builder.AddSerilog();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();


var app = builder.Build();// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// W jaki sposób zapisaæ konfiguracje corsa w appsettings? 
app.UseCors(p => p.WithOrigins("http://localhost:5173")
    .AllowAnyHeader()
    .AllowAnyMethod());


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
