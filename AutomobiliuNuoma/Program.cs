using AutomobiliuNuoma.Data;
using AutomobiliuNuoma.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Konfigûruokite SQL duomenø bazës prisijungimo eilutæ
string connectionString = builder.Configuration.GetConnectionString("Server=localhost;Database=APIAutomobiliuNuoma1113;Trusted_Connection=True;TrustServerCertificate=true;");

// Registruokite DbContext
builder.Services.AddDbContext<AutomobiliuContext>(options =>
    options.UseSqlServer(connectionString));

// Registruokite Repozitorijas
builder.Services.AddTransient<IAutomobilisRepository, AutomobilisRepository>();
builder.Services.AddTransient<IDarbuotojasRepository, DarbuotojasRepository>();
builder.Services.AddTransient<IKlientasRepository, KlientasRepository>();
builder.Services.AddTransient<INuomosUzsakymasRepository, NuomosUzsakymasRepository>();

// Registruokite Paslaugas
builder.Services.AddTransient<IAutomobilisService, AutomobilisService>();
builder.Services.AddTransient<IDarbuotojasService, DarbuotojasService>();
builder.Services.AddTransient<IKlientasService, KlientasService>();
builder.Services.AddTransient<INuomosUzsakymasService, NuomosUzsakymasService>();

// Pridëkite kontrolerius
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Konfigûruokite HTTP uþklausø apdorojimo grandinæ
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();