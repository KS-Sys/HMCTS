using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMCTS.Modules
{
    internal class TaskModel
    {
        string Task_Title { get; set; }
        string Task_Description { get; set; }
        bool Task_Status { get; set; }
        DateTime Task_Due { get; set; }

    }
}
