using DataAccess.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public class DbHelper
    {
        public static void InitializeDb(bool state)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DemoAppContext, Configuration>());
            using (var dbContext = new DemoAppContext())
            {
                dbContext.Database.Initialize(state);
            }
        }
    }
}
