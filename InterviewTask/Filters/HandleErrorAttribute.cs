using InterviewTask.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterviewTask.Filters
{
    public class UnhandledExceptionAttribute : HandleErrorAttribute
    {
        private readonly ILogger logger;

        public UnhandledExceptionAttribute()
        {
            this.logger = DependencyResolver.Current.GetService<ILogger>();
        }

        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled || filterContext.HttpContext.IsCustomErrorEnabled) { return; }

            logger.LogCritical($"Unhandled Exception Raised:- {PageAccessed(filterContext)}, Exception Message: {filterContext.Exception.Message}");

            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult() { ViewName = "Error" };
        }

        private string PageAccessed(ExceptionContext context)
        {
            string controller = context.RequestContext.RouteData.Values["controller"].ToString();
            string action = context.RequestContext.RouteData.Values["action"].ToString();

            return $"PageName: {controller}-{action}";
        }
    }
}
