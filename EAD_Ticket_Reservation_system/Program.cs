using EAD_Ticket_Reservation_system.Models;
using EAD_Ticket_Reservation_system.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy",
        builder => builder.WithOrigins("http://localhost:3000") // Update with your React app URL
            .AllowAnyMethod()
            .AllowAnyHeader());
});


builder.Services.Configure<DatabaseConnection>(
    builder.Configuration.GetSection("DatabaseConnection"));

// building the services
builder.Services.AddSingleton<Traveller>();
builder.Services.AddSingleton<Train>();
builder.Services.AddSingleton<User>();
builder.Services.AddSingleton<Reservation>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Use CORS middleware
app.UseCors("ReactPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
