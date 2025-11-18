using System.Net;
using System.Text.Json;
using SahaCepteApp.Domain.Wrappers;

namespace SahaCepteApp.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            // İstek pipeline'da bir sonraki adıma geçer (Controller'a doğru)
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            // Hata oluşursa yakalarız
            _logger.LogError(ex, "Beklenmedik bir hata oluştu: {Message}", ex.Message);

            // Hata yanıtını standart JSON formatına satirize
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Hata Kodu: 500 Internal Server Error (Sunucu Hatası)
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        // Kullanıcıya dönülecek mesaj (Stack trace göstermeden)
        var response = ServiceResponse<object>.FailureResult("Sunucu tarafında beklenmedik bir hata oluştu. Lütfen daha sonra tekrar deneyin.");

        // Debug için Exception detayını loglayabilirsiniz, ancak Client'a dönmemeliyiz.

        // JSON'a çevirip yanıt olarak yazarız
        var jsonResponse = JsonSerializer.Serialize(response);

        return context.Response.WriteAsync(jsonResponse);
    }
}