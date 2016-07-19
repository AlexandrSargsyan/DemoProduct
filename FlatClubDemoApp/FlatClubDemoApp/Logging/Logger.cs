using System;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace FlatClubDemoApp.Logging
{
    internal class Logger : ILogger
    {
        public void Write(string logData)
        {
            LogMananger.Write(logData);
        }

        public void Write(Exception originalException)
        {
            try
            {
                var exceptionFullInfo = LogDataProvider.GetExceptionFullInfo(originalException);
                LogMananger.Write(exceptionFullInfo.ToString());
            }
            catch (Exception ex)
            {
                LogMananger.Write(ex.ToString());
                LogMananger.Write(originalException.ToString());
            }
        }

        public static void WriteHangfireLog(string logData)
        {
            LogMananger.Write(logData, "HangfireRollingFlatFileTraceListener");
        }

        public void WriteClientLog(string logData)
        {
            LogMananger.Write(logData, "LogDataScriptsRollingFlatFileTraceListener");
        }

        public void WriteWebCrawlingLog(string logData)
        {
            LogMananger.Write(logData, "WebCrawlingRollingFlatFileTraceListener");
        }

        private static class LogMananger
        {
            private static readonly Lazy<LogWriter> logWriter = new Lazy<LogWriter>(() =>
            {
                var configurationSource = new FileConfigurationSource("Web.EnterpriseLibrary.config");
                var factory = new LogWriterFactory(configurationSource);
                return factory.Create();
            });

            private static LogWriter LogWriter => logWriter.Value;

            internal static void Write(string data, string category = "RollingFlatFileTraceListener")
            {
                LogWriter.Write(data, category);
            }
        }
    }
}
