using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Contracts;

namespace TheShop
{
    public class WorkflowEngine
    {
        public void Run(IWorkflow workflow)
        {
            foreach (var task in workflow.GetTasks())
            {
                task.Execute();
            }
        }
    }
}
