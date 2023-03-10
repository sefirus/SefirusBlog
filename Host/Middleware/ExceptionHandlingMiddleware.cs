using System.Net;
using Core.ViewModels;

namespace Host.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(
                context, 
                HttpStatusCode.InternalServerError, 
                e.GetType().Name + e.Message + "   \n" + e.StackTrace);
        }
    }
    
    private Task HandleExceptionAsync(HttpContext context, HttpStatusCode errorCode, string errorMessage)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)errorCode;
        return context.Response.WriteAsync(new ErrorDetails
        {
            StatusCode = context.Response.StatusCode,
            Message = errorMessage
        }.ToString());
    }
}
