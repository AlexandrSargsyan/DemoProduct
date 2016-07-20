namespace FlatClubDemoApp.Logging
{
    public class ClientLogData
    {
        public string Url { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public string Cause { get; set; }

        public string BrowserInfo { get; set; }
    }
}