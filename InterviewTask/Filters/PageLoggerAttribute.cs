using InterviewTask.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterviewTask.Filters
{
    public class PageLoggerAttribute : ActionFilterAttribute
    {
        private readonly ILogger logger;

        public PageLoggerAttribute()
        {
            this.logger = DependencyResolver.Current.GetService<ILogger>();
        }
   
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            string ipAddress = LogIpAddress(context);
            string accessTime = AccessTime();
            string pageAccessed = PageAccessed(context);

            logger.LogInformation($"Page Accessed:- {pageAccessed}, {accessTime}, {ipAddress} ");

            base.OnResultExecuting(context);
        }

        private string LogIpAddress(ResultExecutingContext context)
        {
            string ipAddress = context.HttpContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ipAddress)) { ipAddress = context.HttpContext.Request.ServerVariables["REMOTE_ADDR"]; }

            return $"IP Address: {ipAddress}";
        }

        private string AccessTime()
        {
            return $"AccessTime: {DateTime.Now}";
        }

        private string PageAccessed(ResultExecutingContext context)
        {
            string controller = context.RequestContext.RouteData.Values["controller"].ToString();
            string action = context.RequestContext.RouteData.Values["action"].ToString();

            return $"PageName: {controller}-{action}";
        }
    }
}