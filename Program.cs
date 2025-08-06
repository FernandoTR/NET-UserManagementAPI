using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerUI;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>(); // 1. Manejo global de errores
app.UseMiddleware<TokenAuthenticationMiddleware>(); // 2. Seguridad
app.UseMiddleware<RequestResponseLoggingMiddleware>(); // 3. Logging

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();