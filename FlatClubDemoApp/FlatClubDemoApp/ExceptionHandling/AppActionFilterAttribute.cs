using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace FlatClubDemoApp.ExceptionHandling
{
    public class AppActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response?.Content is ObjectContent)
            {
                actionExecutedContext.Response.Content
                    .Headers.Add("X-Requested-ResponseMessage",
                        "X-Requested-ResponseMessage");
            }

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}