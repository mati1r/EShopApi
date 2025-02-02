using Core.Exceptions;
using System.Net;
using System.Text.Json;

namespace Application.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        HttpStatusCode status;
        string message;

        switch (ex)
        {
            case BadRequestException badReqEx:
                status = HttpStatusCode.BadRequest;
                message = ex.Message;
                break;
            case AuthorizationErrorException authEx:
                status = HttpStatusCode.BadRequest;
                message = authEx.Message;
                break;
            case AppErrorException appEx:
                status = HttpStatusCode.InternalServerError;
                message = appEx.Message;
                break;
            default:
                status = HttpStatusCode.InternalServerError;
                message = "An unexpected error occurred.";
                break;

        }

        var response = new
        {
            status = (int)status,
            error = message
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;
        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
