using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Contracts;

namespace TheShop.Contracts
{
    public interface IWorkflow
    {
        void AddTask(ITask task);
        void RemoveTask(ITask task);
        IEnumerable<ITask> GetTasks();
    }
}
