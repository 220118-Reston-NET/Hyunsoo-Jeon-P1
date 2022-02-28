global using Serilog;
using BL;
using DL;


var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
            .WriteTo.File("./logs/server.txt")
            .CreateLogger();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository>(repo => new SQLRepository(builder.Configuration.GetConnectionString("Reference2DB")));
builder.Services.AddScoped<ICustomerBL, CustomerBL>();
builder.Services.AddScoped<IOrderBL, OrderBL>();
builder.Services.AddScoped<IInventoryBL, InventoryBL>();
builder.Services.AddScoped<IUserBL, UserBL>();

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
