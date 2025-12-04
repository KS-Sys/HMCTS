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
        private TaskModel new_task;

        public TaskService() { }

        public TaskService(TaskModel new_task)
        {
            this.new_task = new_task;
        }

        public List<TaskModel> CheckOverDueTask()
        {
            List<TaskModel> list = new List<TaskModel>();

            //string comparedatetime = DateTime.Now.ToString();

            string query = "SELECT * FROM moj_db WHERE duedate < NOW() AND status = 0";

            try
            {
                var connection = DB_connector.Instance().GetConnected;

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TaskModel model = new TaskModel();

                            model.TaskID = Convert.ToInt32(reader["TaskID"]);
                            model.Task_Title = reader["Title"].ToString();
                            model.Task_Description = reader["Description"].ToString();
                            model.Task_Status = Convert.ToBoolean(reader["state"]);
                            model.Task_Due = reader["due_date"].ToString();

                            list.Add(model);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        public void CreateNewTable()
        {
            string query = @"CREATE TABLE IF NOT EXISTS moj_db (
                        TaskID INT AUTO_INCREMENT PRIMARY KEY,
                        task VARCHAR(255) NOT NULL,
                        description TEXT,
                        status TINYINT(1) DEFAULT 0,
                        duedate VARCHAR(100)
                    );";

            try
            {
                var connection = DB_connector.Instance().GetConnected;

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Table 'tasks' verified.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Create_Task(TaskModel task)
        {

            string query = "INSERT INTO moj_db (task, description, status, duedate) VALUES (@task, @description, @status, @duedate)";

            try
            {
                var connection = DB_connector.Instance().GetConnected;

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@task", task.Task_Title);
                    cmd.Parameters.AddWithValue("@description", task.Task_Description);
                    cmd.Parameters.AddWithValue("@status", task.Task_Status);
                    cmd.Parameters.AddWithValue("@duedate", task.Task_Due);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Task added all OK!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public int Delete_Task(TaskModel task)
        {
            throw new NotImplementedException();
        }


        public List<TaskModel> GetAllTasks()
        {
            List<TaskModel> list = new List<TaskModel>();

            string query = "SELECT * FROM moj_db";

            try
            {
                var connection = DB_connector.Instance().GetConnected;

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TaskModel model = new TaskModel();

                            model.TaskID = Convert.ToInt32(reader["TaskID"]);
                            model.Task_Title = reader["Title"].ToString();
                            model.Task_Description = reader["Description"].ToString();
                            model.Task_Status = Convert.ToBoolean(reader["state"]);
                            model.Task_Due = reader["due_date"].ToString();

                            list.Add(model);

                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }


        public int GetTaskByid(TaskModel task)
        {
            throw new NotImplementedException();
        }

        public void Update_Task(TaskModel task)
        {
            throw new NotImplementedException();
        }
    }
}
