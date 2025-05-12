using GymBookingSystem.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GymBookingSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ---  AddControllersWithViews() ---
builder.Services.AddControllersWithViews();

// Session (cho Captcha)
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
});

// Swagger ,test API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Cho ph�p ph?c v? file t?nh (CSS/JS trong wwwroot)
app.UseStaticFiles();

app.UseRouting();
// CORS v� Authorization 
app.UseSession();
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthorization();

// --- Map route MVC , Map route API ---
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Register}/{id?}"
);

// C�c API attribute routes v?n ch?y b�nh th??ng
app.MapControllers();

app.Run();
