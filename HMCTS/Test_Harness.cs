using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMCTS.Modules;

namespace HMCTS
{
    internal class Test_Harness
    {
        static void Main(string[] args)
        {
            // this is where the main code will be executed for the back_end API
            // I am using MYSQL.
            debug();
        }

        public static void debug()
        {
            var dbtest = DB_connector.Instance();
            dbtest.OpenConnection();
            Console.Read();
        }
    }
}
