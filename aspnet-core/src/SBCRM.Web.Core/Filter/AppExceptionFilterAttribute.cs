using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace SBCRM.Web.Filter
{
    public class AppExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private ILogger Logger { get; }

        public AppExceptionFilterAttribute(ILoggerFactory loggerFactory)
        {
            Logger = loggerFactory.CreateLogger<AppExceptionFilterAttribute>();
        }


        public override void OnException(ExceptionContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            string apiRoute = string.Empty;

            HttpRequest request = context.HttpContext.Request;

            if (request.Path.HasValue)
            {
                var x = request.Path.Value.Split('/');
                if (x.Length > 0)
                {
                    apiRoute = x[x.Length - 1].Split('?')[0];
                }
            }

            Logger.LogError(context.Exception, $"{apiRoute} - {context.Exception.ToString()}");
        }

    }
}
