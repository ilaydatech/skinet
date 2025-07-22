using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(opt =>  // Veritabanı bağlantısını ayarla
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));  // SQL Server ve bağlantı bilgisini kullan
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
// CORS desteğini aktive et
builder.Services.AddCors();

var app = builder.Build();

// Uygulama başlamadan önce hata yakalama middleware’i çalıştır
app.UseMiddleware<ExceptionMiddleware>();

// CORS ayarları → sadece frontend’in (localhost:4200) bu API’ye ulaşmasına izin verir
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyMethod()
.WithOrigins("http://localhost:4200","https://localhost:4200"));

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
