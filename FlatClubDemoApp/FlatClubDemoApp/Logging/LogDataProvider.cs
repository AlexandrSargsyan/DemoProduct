using System;
using System.Net;
using System.Web;
using FlatClubDemoApp.ExceptionHandling;


namespace FlatClubDemoApp.Logging
{
    internal class LogDataProvider
    {
        internal static ExceptionFullInfo GetExceptionFullInfo(Exception exception)
        {

            var exceptionFullInfo = new ExceptionFullInfo
            {
                UserId = "Anonymous User",
                OriginalException = exception
            };

            if (HttpContext.Current?.Request != null)
            {
                exceptionFullInfo.IpAddress = HttpContext.Current.Request.UserHostName;
                exceptionFullInfo.RequestMethod = HttpContext.Current.Request.RequestType;
                exceptionFullInfo.RequestUri = HttpContext.Current.Request.Url.ToString();
            }

            // ReSharper disable once InvertIf
            if (HttpContext.Current != null && HttpContext.Current.User != null)
            {
                exceptionFullInfo.UserId = HttpContext.Current.User.Identity.Name;
            }

            return exceptionFullInfo;
        }
    }
}