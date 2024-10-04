

using bezoni_shoes_store.Application;
using bezoni_shoes_store.Infrastucture;
using bezoni_shoes_store.Server;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Start code
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPresentation();


// Cấu hình Serilog
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// -----END builder code-----

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();






var app = builder.Build();

app.UseDefaultFiles();

app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Some code here
app.UseExceptionHandler("/error");
app.UseAuthentication();
app.UseSerilogRequestLogging();



// -----END app code-----
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
