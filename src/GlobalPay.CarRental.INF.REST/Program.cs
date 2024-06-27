using GlobalPay.CarRental.INF.DB;
using GlobalPay.CarRental.APP;
using GlobalPay.CarRental.INF.REST;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfDbDependencies(builder.Configuration);
builder.Services.AddAppDbDependencies();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDefaultData();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();