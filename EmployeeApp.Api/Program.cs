//Usings

using EmployeeApp.Infrastructure.AppData;
using EmployeeApp.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = builder.Configuration;
var stringConnection = new DbConnection(config.GetConnectionString("SQL"));
builder.Services.AddSingleton(stringConnection);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Service Employee
builder.Services.AddSingleton<IServiceEmployee, ServiceEmployee>();

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
