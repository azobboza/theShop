using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Contracts;

namespace TheShop
{
    public class Workflow : IWorkflow
    {
        private readonly List<ITask> _tasks;
        public Workflow()
        {
            _tasks = new List<ITask>();
        }
        public void AddTask(ITask task)
        {
            _tasks.Add(task);
        }

        public IEnumerable<ITask> GetTasks()
        {
            return _tasks;
        }

        public void RemoveTask(ITask task)
        {
            _tasks.Remove(task);
        }
    }
}
