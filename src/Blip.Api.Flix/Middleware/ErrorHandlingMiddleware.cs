﻿using System;
using System.Net;
using System.Threading.Tasks;
using Blip.Api.Flix.Models;
using Lime.Protocol;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;

namespace Blip.Api.Flix.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Invoke Method, to validate requisition errors
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
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

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Thrown whenever a RestEase call returns with a non-success HttpStatusCode
            if(exception is RestEase.ApiException apiException)
            {
                context.Response.StatusCode = (int)apiException.StatusCode;
                _logger.Error(apiException, "[{@user}] Error: {@exception}", context.Request.Headers[Constants.BLIP_USER_HEADER], exception.Message);
            }
            else
            {
                _logger.Error(exception, "[{@user}] Error: {@exception}", context.Request.Headers[Constants.BLIP_USER_HEADER], exception.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            context.Response.ContentType = MediaType.ApplicationJson;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(exception.Message + exception.StackTrace));
        }
    }
}
