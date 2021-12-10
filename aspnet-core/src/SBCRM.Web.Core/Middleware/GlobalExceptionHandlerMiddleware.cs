using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SBCRM.Web.Common;

namespace SBCRM.Web.Middleware
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger Logger { get; }

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            Logger = loggerFactory.CreateLogger<GlobalExceptionHandlerMiddleware>();
        }

        /// <summary>
        /// Intercept request and handle any exception
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                Logger.LogError("[*GLOBAL_ERROR_L1*] in {@Url} -> {@Exception}", httpContext.Request.GetDisplayUrl(), ex);
                //Generic message
                await UpdateHttpResponse(httpContext, "GE500", "An error occurred while processing the operation, please try again in a few moments.");
            }
        }

        /// <summary>
        /// Update http response
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="codeError"></param>
        /// <param name="messageError"></param>
        /// <returns></returns>
        private static async Task UpdateHttpResponse(HttpContext httpContext, string codeError, string messageError)
        {
            httpContext.Response.Clear();
            httpContext.Response.ContentType = "application/json";

            //httpContext.Response.StatusCode = (codeError.Equals(WebCodes.ErrorUnauthorized))
            //    ? StatusCodes.Status401Unauthorized
            //    : StatusCodes.Status500InternalServerError;

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var response = new GenericResponse<string>
            {
                Error = new GenericError()
                {
                    Code = 0,
                    Message = messageError
                }
            };
            var jsonResponse = httpContext.Response.WriteAsync(text: JsonConvert.SerializeObject(response));
            await jsonResponse;
        }
    }
}
