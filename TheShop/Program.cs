using System;
using System.Collections.Generic;
using TheShop.Contracts;
using TheShop.Entities;
using TheShop.ExternalServices;
using TheShop.LoggerService;
using TheShop.Persistance;

namespace TheShop
{
	internal class Program
	{
		private static void Main(string[] args)
		{
            int articleId = 1;
            int buyerId = 1;
            int maxExpectedPrice = 100;
            
            var suppliers = new List<ISupplier>
            {
                new Supplier1(),
                new Supplier2(),
                new Supplier3(),
            };
            
            var orderArticleTask = new OrderArticleTask(articleId, maxExpectedPrice, buyerId, suppliers);
            var displayArticleTask = new DisplayArticleTask(articleId);

            var workflow = new Workflow();
            workflow.AddTask(orderArticleTask);
            workflow.AddTask(displayArticleTask);

            var workflowEngine = new WorkflowEngine();

            try
            {
                workflowEngine.Run(workflow);
            }
            catch (Exception ex)
            {
                LoggerManager.LogError("The application terminated with an error.");
                LoggerManager.LogError($"Exception: {ex} ");
            }

			Console.ReadKey();
		}
	}
}