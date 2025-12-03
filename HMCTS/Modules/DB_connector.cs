using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace HMCTS.Modules
{
    internal class DB_connector
    {
        private DB_connector()
        {

        }
        private static DB_connector _instance = null;
        public MySqlConnection GetConnected { get; set; }

        public void OpenConnection()
        {

        }

        public void CloseConnection()
        {

        }
    }
}
