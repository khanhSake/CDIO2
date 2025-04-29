using GymBookingSystem.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// --- Add DbContext --- 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<GymBookingSystemContext>(options =>
    options.UseSqlServer(connectionString));
// ---------------------

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --- Configure CORS --- 
app.UseCors(policy => policy
    .AllowAnyOrigin()   // Allow requests from any origin (for development)
    .AllowAnyMethod() // Allow any HTTP method (GET, POST, etc.)
    .AllowAnyHeader()); // Allow any HTTP headers
// ----------------------

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); // Temporarily disable for HTTP testing

app.UseAuthorization();

app.MapControllers();

app.Run();
