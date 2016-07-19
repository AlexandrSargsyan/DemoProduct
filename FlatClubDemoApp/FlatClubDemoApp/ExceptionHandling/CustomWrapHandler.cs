using System;
using System.Globalization;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;


namespace FlatClubDemoApp.ExceptionHandling
{
    internal class CustomWrapHandler : IExceptionHandler
    {
        private readonly ExceptionMessageResolver exceptionMessageResolver;
        private readonly Type wrapExceptionType;

        public CustomWrapHandler(Type wrapExceptionType)
            : this(new ExceptionMessageResolver(), wrapExceptionType)
        { }

        private CustomWrapHandler(ExceptionMessageResolver exceptionMessageResolver, Type wrapExceptionType)
        {
            if (wrapExceptionType == null) throw new ArgumentNullException("wrapExceptionType");
            if (!typeof(Exception).IsAssignableFrom(wrapExceptionType))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture,
                    Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Properties.Resources.ExceptionTypeNotException, wrapExceptionType.Name), "wrapExceptionType");
            }

            this.exceptionMessageResolver = exceptionMessageResolver;
            this.wrapExceptionType = wrapExceptionType;
        }

        public Type WrapExceptionType => wrapExceptionType;

        public Exception HandleException(Exception exception, Guid handlingInstanceId)
        {
            var wrapExceptionMessage = this.exceptionMessageResolver.GetString(exception);

            return WrapException(
                exception,
                ExceptionUtility.FormatExceptionMessage(wrapExceptionMessage, handlingInstanceId));
        }

        private Exception WrapException(Exception originalException, string wrapExceptionMessage)
        {
            object[] extraParameters = new object[2];
            extraParameters[0] = wrapExceptionMessage;
            extraParameters[1] = originalException;
            return (Exception)Activator.CreateInstance(wrapExceptionType, extraParameters);
        }
    }
}