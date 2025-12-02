using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMCTS.Modules
{
    internal interface ITaskService
    {
        void Create_Task();

        List<string> GetAllTasks();

        int GetTaskByid();

        void Update_Task();

        int Delete_Task();

        List<string> CheckOverDueTask();
    }
}
