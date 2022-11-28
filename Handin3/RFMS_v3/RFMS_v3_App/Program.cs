using RFMS_v3_App.Models;
using RFMS_v3_App.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var connectionString = builder.Configuration["ConnectionString"];
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDB"));

builder.Services.AddSingleton<CitizenDbService>();
builder.Services.AddSingleton<FacilityDbService>();
builder.Services.AddSingleton<BookingDbService>();
builder.Services.AddSingleton<ReservationDbService>();
builder.Services.AddSingleton<MaintainceInterventionDbService>();


builder.Services.AddControllers();
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
