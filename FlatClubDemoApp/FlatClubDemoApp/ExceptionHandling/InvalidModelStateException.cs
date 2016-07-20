using System;

namespace FlatClubDemoApp.ExceptionHandling
{
    public class InvalidModelStateException : Exception
    {
        public InvalidModelStateException(string message) : base(message)
        {
        }

        public InvalidModelStateException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}