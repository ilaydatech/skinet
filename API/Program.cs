using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<StoreContext>(opt =>  // Veritabanı bağlantısını ayarla
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));  // SQL Server ve bağlantı bilgisini kullan
});

var app = builder.Build();

app.MapControllers();

app.Run();
