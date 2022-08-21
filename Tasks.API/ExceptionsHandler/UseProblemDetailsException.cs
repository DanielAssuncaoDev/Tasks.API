using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tasks.Data.ExceptionHandler;
using Tasks.Domain.ExceptionHandler;

namespace Tasks.API.ExceptionsHandler
{
    internal static class UseProblemDetailsException
    {
        internal static void UseProblemDetailsExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var excpetionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (excpetionHandlerFeature is not null)
                    {
                        var excption = excpetionHandlerFeature.Error;
                        string message;

                        switch (excption)
                        {
                            case ApiLayerException apiLayerExcption:
                                message = apiLayerExcption.Message;
                                break;

                            case DomainLayerException domainLayerException:
                                message = domainLayerException.Message;
                                break;

                            case DataLayerException dataLayerException:
                                message = dataLayerException.Message;
                                break;

                            default:
                                message = "Erro interno. Favor entrar em contato com o suporte.";
                                break;
                        }

                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        context.Response.ContentType = "application/problem+json";

                        var json = JsonConvert.SerializeObject(new { Message = message }, new JsonSerializerSettings().Formatting);
                        await context.Response.WriteAsync(json);
                    }

                });
            });
        }

    }
}
