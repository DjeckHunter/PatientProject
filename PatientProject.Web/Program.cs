using Microsoft.Extensions.Configuration;
using PatientProject.Infrastructure;
using PatientProject.Core;

string CONNECTION_NAME = "PostgreSQL";

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRepositoryContext(configuration.GetConnectionString(CONNECTION_NAME));
builder.Services.AddRepositoryInfrastructure();
builder.Services.AddServicesImplementation();

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