using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using web_service_calculadora_despliegue.Data;

var builder = WebApplication.CreateBuilder(args);

// Registrar DbContext con PostgreSQL
builder.Services.AddDbContext<OperacionesDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection")));

// Registrar servicios para controllers
builder.Services.AddControllers();

// Agregar Swagger para la documentación de la API
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API de Aritmetica", Version = "v1" });
});

var app = builder.Build();

// Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita Swagger
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Aritmetica v1");
    });
}

app.UseAuthorization();
app.MapControllers();
app.Run();
