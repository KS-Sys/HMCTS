using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace HMCTS.logic
{
    /// <summary>
    /// I created a singleton class to manage the database connection and put in in the backend logic project
    /// </summary>
    public class DB_connector
    {
        /// <summary>
        /// I had issues with my code so i had to add a private constructor to prevent instantiation from outside
        /// </summary>
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

        /// <summary>
        /// the boolean below connects to the moj_db database on localhost at port 3306 with user root and password password
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// the method below closes the connection to the database but was depricated because i dropped the console project
        /// </summary>
        public void CloseConnection()
        {
            GetConnected.Close();
        }

        
    }
}
