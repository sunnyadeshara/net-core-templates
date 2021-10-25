using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace CleanArchitectureTemplate.API.Middleware
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseFluentValidationExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseExceptionHandler(x =>
            {
                x.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;

                    if (!(exception is ValidationException validationException))
                    {
                        throw exception;
                    }

                    var errors = validationException.Errors.Select(x => new ErrorModel
                    {
                        PropertyName = x.PropertyName,
                        ErrorMessage = x.ErrorMessage
                    });

                    var errorsText = JsonSerializer.Serialize(errors);
                    context.Response.StatusCode = 400;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(errorsText, Encoding.UTF8);
                });
            });
        }
    }

    public class ErrorModel
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}