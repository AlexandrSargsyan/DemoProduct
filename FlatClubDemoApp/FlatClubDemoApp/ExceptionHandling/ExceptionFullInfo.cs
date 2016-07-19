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
            var message = $"{Environment.NewLine}" +
                  $"User Id: {this.UserId}{Environment.NewLine}"
                + $"Request Uri: {this.RequestUri}{Environment.NewLine}"
                + $"Ip Address: {this.IpAddress}{Environment.NewLine}"
                + $"Original Exception: {this.OriginalException}{Environment.NewLine}";

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

            message += $"LoaderExceptions: {loaderExceptions}{Environment.NewLine}";

            return message;
        }
    }
}