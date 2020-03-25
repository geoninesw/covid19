using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Covid19.Core.Filters
{
    public class AuthorizedUserAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var result = context.Result;
            // Do something with Result.
            if (context.Canceled == true)
            {
                // Action execution was short-circuited by another filter.
            }

            if (context.Exception != null)
            {
                // Exception thrown by action or action filter.
                // Set to null to handle the exception.
                context.Exception = null;
            }
            base.OnActionExecuted(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var isAuthorized = context.HttpContext.Session.Keys.Contains("IS_AUTHORIZED_USER") && context.HttpContext.Session.GetInt32("IS_AUTHORIZED_USER") == 1;
            if(!isAuthorized)
            {
                context.Result = new RedirectToActionResult("Login", "Member", null);
            }
        }
    }
}
