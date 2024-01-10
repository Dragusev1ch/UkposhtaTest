using APIUkrposhtaTest.Services;
using DALUkrposhtaTest.DbService.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<EmployeeDataAccess>(_ =>
{
     builder.Configuration.GetConnectionString("DefaultConnection");
    return new EmployeeDataAccess(connectionString);
}); 
builder.Services.AddScoped<EmployeeService>();

var app = builder.Build();

// Налаштування конвеєру HTTP запитів
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();