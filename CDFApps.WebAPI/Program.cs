using CDFApps.Data;
using CDFApps.Services;
using CDFApps.Services.Interfaces;
using CDFApps.Services.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connect = builder.Configuration.GetConnectionString("PersonalConnection");


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connect, b => b.MigrationsAssembly("CDFApps.Data")));

builder.Services.AddScoped<IBoxesRepository, BoxesRepository>();
builder.Services.AddScoped<IWarehouseJobsRepository, WarehouseJobsRepository>();
builder.Services.AddTransient<UnitOfWork>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
