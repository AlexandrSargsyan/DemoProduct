using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FlatClubDemoApp.ExceptionHandling
{
    public class ModelStateValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext httpActionContext)
        {
            if (httpActionContext.ModelState.IsValid) return;

            var stringBuilder = new StringBuilder();
            // ReSharper disable once LoopCanBePartlyConvertedToQuery
            foreach (var values in httpActionContext.ModelState.Values)
            {
                foreach (var error in values.Errors)
                {
                    stringBuilder.Append(error.Exception);
                    stringBuilder.AppendLine();
                }
            }

            throw new InvalidModelStateException("The input data isn't in valid state.",
                new InvalidModelStateException(stringBuilder.ToString()));
        }
    }
}