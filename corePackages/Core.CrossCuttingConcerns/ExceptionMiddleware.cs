using System.Net;
using Core.Persistence.DtoBaseModel;
using Core.Shared;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }
    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        if (exception.GetType() == typeof(BusinessException)) return CreateBusinessException(context, exception);
        if (exception.GetType() == typeof(AuthorizationException)) return CreateAuthorizationException(context, exception);
        if (exception.GetType() == typeof(ForbiddenException)) return CreateForbiddenException(context, exception);
        return CreateInternalException(context, exception);
    }
    private Task CreateBusinessException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);

        return context.Response.WriteAsync(JsonConvert.SerializeObject(new Response<ResponseDto>
        {
            Message = exception.Message,
            StatusCode = HttpStatusCode.BadRequest,
        }));
    }
    private Task CreateAuthorizationException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.Unauthorized);

        return context.Response.WriteAsync(JsonConvert.SerializeObject(new Response<ResponseDto>
        {
            Message = exception.Message,
            StatusCode = HttpStatusCode.Unauthorized,
        }));
    }
    private Task CreateForbiddenException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.Forbidden);

        return context.Response.WriteAsync(JsonConvert.SerializeObject(new Response<ResponseDto>
        {
            Message = exception.Message,
            StatusCode = HttpStatusCode.Forbidden,
        }));
    }
    private Task CreateInternalException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);

        return context.Response.WriteAsync(JsonConvert.SerializeObject(new Response<ResponseDto>
        {
            Message = exception.Message,
            StatusCode = HttpStatusCode.InternalServerError,
        }));
    }
}
