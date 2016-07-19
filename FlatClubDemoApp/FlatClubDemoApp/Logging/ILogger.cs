using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatClubDemoApp.Logging
{
    public interface ILogger
    {
        void Write(string logData);

        void Write(Exception ex);

        void WriteClientLog(string logData);

        void WriteWebCrawlingLog(string logData);
    }
}
