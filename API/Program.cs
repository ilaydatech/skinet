using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<StoreContext>(opt =>  // Veritabanı bağlantısını ayarla
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));  // SQL Server ve bağlantı bilgisini kullan
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

app.MapControllers();
//Bu try-catch, veritabanı oluşturma/güncelleme ve veri ekleme işlemlerinde hata olursa, 
//hatayı konsolda göstermek ve uygulamayı doğru şekilde sonlandırmak için kullanılıyor.
try
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<StoreContext>();
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context);
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    throw;
}

app.Run();
