using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMCTS.logic
{
    /// <summary>
    /// i have created a class that only holds data, it is just a container and does not
    /// know anything about mysql connections.
    /// </summary>
    public class TaskModel
    {
        public int TaskID { get; set; }
        public string Task_Title { get; set; }
        public string Task_Description { get; set; }
        public bool Task_Status { get; set; }
        public string Task_Due { get; set; }

        /// <summary>
        /// I have added a contructor here to make creating tasks easier
        /// </summary>
        /// <param name="title"></param>
        /// <param name="desc"></param>
        /// <param name="due"></param>
        public TaskModel(string title, string desc, string due)
        {
            Task_Title = title;
            Task_Description = desc;
            Task_Status = false;
            Task_Due = due;
        }
        /// <summary>
        /// I have added a empty constructor for a cs7036 error from generating
        /// </summary>
        public TaskModel()
        {
        }
    }
}
