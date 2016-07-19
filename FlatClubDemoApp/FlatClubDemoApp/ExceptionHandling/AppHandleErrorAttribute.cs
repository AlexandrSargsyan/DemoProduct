using System.Web.Mvc;
using FlatClubDemoApp.Logging;

namespace FlatClubDemoApp.ExceptionHandling
{
    public sealed class AppHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var logger = AppServiceLocator.Current.GetInstance<ILogger>();
            logger.Write(filterContext.Exception);

            base.OnException(filterContext);
        }
    }
}