using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using API.Middleware;
using StackExchange.Redis;
using Infrastructure;
using Infrastructure.Services;
using Core.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(opt =>  // Veritabanı bağlantısını ayarla
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));  // SQL Server ve bağlantı bilgisini kullan
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IPaymentService, PaymentService>();
// CORS desteğini aktive et
builder.Services.AddCors();

builder.Services.AddSingleton<IConnectionMultiplexer>(config =>
{
    var connString = builder.Configuration.GetConnectionString("Redis")
    ?? throw new Exception("Cannot get redis connection string");
    var configuration = ConfigurationOptions.Parse(connString, true);
    return ConnectionMultiplexer.Connect(configuration);
});

builder.Services.AddSingleton<ICartService, CartService>();
builder.Services.AddAuthentication(); //AddAuthentication() → JWT ya da Cookie gibi seçilen authentication mekanizmasını aktive ediyor.
builder.Services.AddIdentityApiEndpoints<AppUser>() //Identity API endpoints (register, login, logout, password reset vb.) otomatik ekleniyor.
     .AddEntityFrameworkStores<StoreContext>(); //Identity kullanıcı ve rol verileri StoreContext üzerinden Entity Framework ile SQL Server’da tutuluyor.


//for autantication

var app = builder.Build();

// Uygulama başlamadan önce hata yakalama middleware’i çalıştır
app.UseMiddleware<ExceptionMiddleware>();

// CORS ayarları → sadece frontend’in (localhost:4200) bu API’ye ulaşmasına izin verir
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyMethod().AllowCredentials()
.WithOrigins("http://localhost:4200","https://localhost:4200"));

app.MapControllers();
app.MapGroup("api").MapIdentityApi<AppUser>(); // API tabanlı default endpoint’leri aktif hale geldi -register -login...

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
//Bu try-catch, veritabanı oluşturma/güncelleme ve veri ekleme işlemlerinde hata olursa, 
//hatayı konsolda göstermek ve uygulamayı doğru şekilde sonlandırmak için kullanılıyor.
app.Run();
