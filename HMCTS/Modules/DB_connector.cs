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
        public static DB_connector Instance()
        {
            if (_instance == null)
                _instance = new DB_connector();
            return _instance;
        }

        public bool OpenConnection()
        {
            if(GetConnected == null)
            {
                string conString = "Server = localhost; Port = 3306; Database = moj_db; Uid = root; Pwd = password;";
                GetConnected = new MySqlConnection(conString);
            }
            
            if (GetConnected.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    GetConnected.Open();
                    Console.WriteLine("database connected");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
     
            }
            return true;

        }

        public void CloseConnection()
        {
            GetConnected.Close();
        }
    }
}
