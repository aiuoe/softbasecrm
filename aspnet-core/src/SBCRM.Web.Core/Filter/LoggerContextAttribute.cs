using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SBCRM.Web.Filter
{
    public class LoggerContextAttribute : ActionFilterAttribute
    {
        private ILogger Logger { get; }

        public LoggerContextAttribute(ILoggerFactory loggerFactory)
        {
            Logger = loggerFactory.CreateLogger<LoggerContextAttribute>();
        }

        /// <summary>
        /// Intercept the HTTP request just before entering the controller
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var inputPayload = DeserializeInputParameters(filterContext.ActionArguments);
            var endPoint = GetEndpoint(filterContext.HttpContext);

            Logger.LogDebug($"[*ACTION_START] '{endPoint}' -> Params:{inputPayload}");
        }


        /// <summary>
        /// Intercept the HTTP request right after the controller returns the response
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var endPoint = GetEndpoint(filterContext.HttpContext);
            var message = $"[*ACTION_END  ] '{endPoint}' -> " +
                          $"{(!(filterContext.Exception is null) ? "Return an error -" : "Return OK200 -")})";
            Logger.LogDebug(message);
        }


        /// <summary>
        /// Deserialize input parameters
        /// </summary>
        /// <param name="paramsMap"></param>
        /// <returns></returns>
        private static string DeserializeInputParameters(IDictionary<string, object> paramsMap)
        {
            return JsonConvert.SerializeObject(paramsMap.Values);
        }

        /// <summary>
        /// Resolve endpoint url
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        private static string GetEndpoint(HttpContext httpContext)
        {
            return httpContext.Request.GetDisplayUrl();
        }
    }
}
