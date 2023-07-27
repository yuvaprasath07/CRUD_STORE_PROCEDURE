using BusinessLayer;
using DataLayerClass;
using EntityDb;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var conectionString = builder.Configuration.GetConnectionString("Students");
builder.Services.AddDbContextPool<EmployeeDbContext>(option => option.UseSqlServer(conectionString));


builder.Services.AddTransient<IDataLayer, DataLayer>();
builder.Services.AddTransient<IBusinessLayre, BusinessLayerClass>();

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
