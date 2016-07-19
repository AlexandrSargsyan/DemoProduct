using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Core
{
   public class DbConfigs
    {
        public static void Initialize(bool state)
        {
            DbHelper.InitializeDb(state);
        }
    }
}
