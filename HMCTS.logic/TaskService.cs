using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace HMCTS.logic
{
    public class TaskService : ITaskService
    {
        private TaskModel? new_task;

        public TaskService() { }

        public TaskService(TaskModel new_task)
        {
            this.new_task = new_task;
        }

        /// <summary>
        /// this method checks for overdue tasks by comparing the due date with the current date and time. but is not implemented in the test harness or api and is for future use.
        /// </summary>
        /// <returns></returns>
        public List<TaskModel> CheckOverDueTask()
        {
            List<TaskModel> list = new List<TaskModel>();

            // this forces the db connection to open as it is returning errors. it is a slight adjustment to the console test harness.
            // it is likely that i will need to do this for every method that accesses the db.
            if (DB_connector.Instance().OpenConnection() == false)
            {
                return list;
            }

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
                            model.Task_Title = reader["task"].ToString();
                            model.Task_Description = reader["description"].ToString();
                            model.Task_Status = Convert.ToBoolean(reader["status"]);
                            model.Task_Due = reader["duedate"].ToString();

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

        /// <summary>
        /// I created this method to create the table if it does not already exist. as it would throw errors otherwise.
        /// </summary>
        public void CreateNewTable()
        {
            string query = @"CREATE TABLE IF NOT EXISTS moj_db (
                        TaskID INT AUTO_INCREMENT PRIMARY KEY,
                        task VARCHAR(255) NOT NULL,
                        description TEXT,
                        status TINYINT(1) DEFAULT 0,
                        duedate DATETIME(100)
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

            // this forces the db connection to open as it is returning errors. it is a slight adjustment to the console test harness.
            // it is likely that i will need to do this for every method that accesses the db.
            if (DB_connector.Instance().OpenConnection() == false)
            {
                return;
            }

            CreateNewTable(); // ensure the table exists before trying to insert data.

            string query = "INSERT INTO moj_db (task, description, status, duedate) VALUES (@task, @description, @status, @duedate)";

            try
            {
                var connection = DB_connector.Instance().GetConnected;

                DateTime pDate = Convert.ToDateTime(task.Task_Due);

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@task", task.Task_Title);
                    cmd.Parameters.AddWithValue("@description", task.Task_Description);
                    cmd.Parameters.AddWithValue("@status", task.Task_Status);
                    cmd.Parameters.AddWithValue("@duedate", pDate);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Task added all OK!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// this is the method to delete a task from the db. it is not implemented in the test harness or api and is for future use.
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Delete_Task(TaskModel task)
        {
            // this forces the db connection to open as it is returning errors. it is a slight adjustment to the console test harness.
            if (DB_connector.Instance().OpenConnection() == false)
            {
                return - 1;
            }

            //query to delete task based on task title.
            string query = "DELETE FROM moj_db WHERE TaskID = @TaskID";

            //try catch statement to execute the delete command.
            try
            {
                var connection = DB_connector.Instance().GetConnected;
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@TaskID", task.TaskID);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Task deleted all OK!");
                    return rowsAffected;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// this is the method to get all tasks from the db and populates it into a list of TaskModel objects.
        /// it is the returned as a list.
        /// </summary>
        /// <returns></returns>
        public List<TaskModel> GetAllTasks()
        {
            List<TaskModel> list = new List<TaskModel>();

            // this forces the db connection to open as it is returning errors. it is a slight adjustment to the console test harness.
            // it is likely that i will need to do this for every method that accesses the db.
            if (DB_connector.Instance().OpenConnection() == false)
            {
                return list;
            }

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
                            model.Task_Title = reader["task"].ToString();
                            model.Task_Description = reader["description"].ToString();
                            model.Task_Status = Convert.ToBoolean(reader["status"]);
                            model.Task_Due = reader["duedate"].ToString();

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

        /// <summary>
        /// i was planning to add a get by id method by id but ran out of time.
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int GetTaskByid(TaskModel task)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// i wanted to add an update method to update existing tasks if i could change their status or details but ran out of time.
        /// </summary>
        /// <param name="task"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Update_Task(TaskModel task)
        {
            throw new NotImplementedException();
        }
    }
}
