using Catalog.Application;
using Catalog.Application.Interface;
using Catalog.Core.Settings;
using Catalog.Infrastructure;
using Catalog.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ConnectionSetting>(builder.Configuration.GetSection("CatalogConnection"));

builder.Services.AddCatalogService(builder.Configuration)
    .AddInfrastructure();


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



app.UseAuthorization();

app.MapControllers();

app.Run();
