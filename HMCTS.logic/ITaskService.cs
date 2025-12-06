using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMCTS.logic
{
    /// <summary>
    /// i created an interface for the task service to implement so i knew what i was going to code and what methods i needed.
    /// </summary>
    internal interface ITaskService
    {
        void Create_Task(TaskModel task);

        void CreateNewTable();

        List<TaskModel> GetAllTasks();

        int GetTaskByid(TaskModel task);

        void Update_Task(TaskModel task);

        int Delete_Task(TaskModel task);

        List<TaskModel> CheckOverDueTask();
    }
}
