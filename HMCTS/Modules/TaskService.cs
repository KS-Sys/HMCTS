using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace HMCTS.Modules
{
    internal class TaskService : ITaskService
    {
        public List<string> CheckOverDueTask()
        {
            throw new NotImplementedException();
        }

        public void Create_Task()
        {
            string sql = "INSERT INTO moj_db (task, description, status, duedate) VALUES (@task, @description, @status, @duedate)";
            throw new NotImplementedException();
        }

        public int Delete_Task()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public int GetTaskByid()
        {
            throw new NotImplementedException();
        }

        public void Update_Task()
        {
            throw new NotImplementedException();
        }
    }
}
