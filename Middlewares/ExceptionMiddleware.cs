using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using ShopBridge.Modals;

namespace ShopBridge.Middleware;

public static class ExceptionMiddleware
{
    public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(options => {
            options.Run(async context => {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (contextFeature != null)
                {
                    await context.Response.WriteAsync(new ErrorDetails
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Internal Server Error"
                    }.ToString()!);
                }
            });
        });
    }
}