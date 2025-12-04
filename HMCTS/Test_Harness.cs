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

            TaskService createservice = new TaskService();

            createservice.CreateNewTable();

            //TaskModel listrun = new TaskModel();

            //TaskService service = new TaskService(listrun);
            //service.GetAllTasks();
            Console.WriteLine("Insert task name");
            string name = Console.ReadLine();

            Console.WriteLine("Insert task description");
            string desc = Console.ReadLine();

            Console.WriteLine("Insert task due date");
            string due = Console.ReadLine();

            TaskModel new_task = new TaskModel(name, desc, due);

            TaskService service = new TaskService(new_task);

            service.Create_Task(new_task);

            dbtest.CloseConnection();
        }
    }
}
