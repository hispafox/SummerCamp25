using ApiPaisesProyecto.BaseDatos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// A-Agregar servicios a la aplicacion.

builder.Services.AddControllers(); // Modelo-Vista-Controlador (MVC) para APIs
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Esto es Swagger/OpenAPI para documentar la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3- Configurar la conexi�n a la base de datos
builder.Services.AddDbContext<ContextoBaseDatos>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// B-Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapGet("/", () => "�Hola, mundo! Esta es una API de ejemplo para pa�ses y apartamentos.");
//app.UseWelcomePage();



app.Run();
