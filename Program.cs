using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using BiBliotecaUser.ORM;
using BiBliotecaUser.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Adicione o contexto do banco de dados
builder.Services.AddDbContext<BibliotecaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registre os repositórios
builder.Services.AddScoped<CategoriaR>();
builder.Services.AddScoped<EmprestimoR>();
builder.Services.AddScoped<FuncionarioR>();
builder.Services.AddScoped<LivroR>();
builder.Services.AddScoped<MembroR>();
builder.Services.AddScoped<ReservaR>();
builder.Services.AddScoped<UsuarioR>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Biblioteca API", Version = "v1" });
});

// Configuração do aplicativo
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Biblioteca API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();