using System;
using System.Data.SqlClient;

namespace FlatClubDemoApp.ExceptionHandling
{
    internal class ExceptionMessageResolver
    {
        public string GetString(Exception exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception), "getString");
            }

            return ResolveMessage(exception);
        }

        private static string ResolveMessage(Exception exception)
        {
            const string DefaultMessage = "A problem has occurred. Please contact with administration.";

            var exception1 = exception as SqlException;
            if (exception1 != null)
            {
                var sqlException = exception1;
                switch (sqlException.ErrorCode)
                {
                    default:
                        return DefaultMessage;
                }
            }

            return DefaultMessage;
        }
    }
}