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

        public TaskService(TaskModel new_task)
        {
            this.new_task = new_task;
        }

        public List<TaskModel> CheckOverDueTask()
        {
            throw new NotImplementedException();
        }

        public void Create_Task(TaskModel task)
        {
            string query = "INSERT INTO moj_db (task, description, status, duedate) VALUES (@task, @description, @status, @duedate)";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
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
                using (MySqlCommand cmd = new MySqlCommand(query))
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
