using System.Net;
using System.Text.Json;
using API.Errors;

namespace API.Middleware;
//Tüm API boyunca oluşan hataları yakalayan özel middleware (ara katman).
// .NET pipeline’ına eklenen hata yakalama katmanı
public class ExceptionMiddleware(IHostEnvironment env, RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context); // Diğer middleware’lere geç
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, env);
        }
    }

 // Hataları özelleştirilmiş JSON formatında döndür
    private static Task HandleExceptionAsync(HttpContext context, Exception ex, IHostEnvironment env)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // 500

        // Geliştirme ortamındaysak hata detayıyla birlikte gönder
        var response = env.IsDevelopment()
            ? new ApiErrorResponse(context.Response.StatusCode, ex.Message, ex.StackTrace)
            : new ApiErrorResponse(context.Response.StatusCode, ex.Message, "Internal server error");
            
        // JSON ayarları (camelCase kullan
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        var json = JsonSerializer.Serialize(response, options);

        return context.Response.WriteAsync(json);
    }
}