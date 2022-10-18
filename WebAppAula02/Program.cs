using Microsoft.EntityFrameworkCore;
using WebAppAula02.Data;
using WebAppAula02.Repository.Interfaces;
using WebAppAula02.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DBContext
builder.Services.AddDbContext<DataContext>(opt => 
opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Dependency
builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<IEstudanteRepository, EstudanteRepository>();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
