using System;
using System.Reflection;

namespace FlatClubDemoApp.ExceptionHandling
{
    public class ExceptionFullInfo : Exception
    {
        public string UserId { get; set; }
        
        public string RequestUri { get; set; }

        public Exception OriginalException { get; set; }

        public string IpAddress { get; set; }

        public string RequestMethod { get; set; }

        public override string ToString()
        {
            var message = string.Format("Request Uri: {0} Ip Address {1} Orignial Exception {2}", RequestUri, IpAddress, OriginalException);
              

            var originalException = OriginalException as ReflectionTypeLoadException;

            if (originalException == null) return message;
            var ex = originalException;
            var loaderExceptions = string.Empty;
            var builder = new System.Text.StringBuilder();
            builder.Append(loaderExceptions);
            foreach (var exception in ex.LoaderExceptions)
            {
                builder.Append(exception);
                builder.Append(Environment.NewLine);
            }

            loaderExceptions = builder.ToString();

            message += String.Format("LoaderExceptions: {0}{1}", loaderExceptions, Environment.NewLine);

            return message;
        }
    }
}