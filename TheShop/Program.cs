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
            var buyer = new Buyer(buyerId, maxExpectedPrice);
            
            var suppliers = new List<ISupplier>
            {
                new Supplier1(),
                new Supplier2(),
                new Supplier3()
            };

            var databaseDriver = new InMemoryDatabase();
            var orderService = new OrderService(suppliers);
            var shopService = new ShopService(orderService, databaseDriver);
            var service = new Service(shopService);

            try
            {
                service.Run(articleId, buyer);
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