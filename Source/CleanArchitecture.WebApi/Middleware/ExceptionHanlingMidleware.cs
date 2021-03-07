using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using CleanArchitecture.Application.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            logger.LogError($"Exception: Path: {context.Request.Path}. Message: {ex.Message}. InnerException: {ex?.InnerException?.Message}");

            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            var result = string.Empty;

            switch (ex)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(new { errors = validationException.Errors.Select(e => e.ErrorMessage) });
                    break;
                case ExceptionBase _:
                    code = ((ExceptionBase)ex).Code;
                    break;
            }

            if (string.IsNullOrEmpty(result))
            {
                result = JsonConvert.SerializeObject(new { errors = new[] { ex.Message } });
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
