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

            var buyer = new Buyer()
            {
                Id = 10,
                MaxExpectedPrice = 500
            };

            List<ISupplier> suppliers = new List<ISupplier>
            {
                new Supplier1(),
                new Supplier2(),
                new Supplier3()
            };

            IDatabaseDriver databaseDriver = new InMemoryDatabase();
			IShopService shopService = new ShopService(suppliers, databaseDriver);

			try
			{
                var article = shopService.OrderArticle(articleId, buyer.MaxExpectedPrice);
                
				shopService.SellArticle(buyer.Id, article);

                shopService.DispalyArticle(article);

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