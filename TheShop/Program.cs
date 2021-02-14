using System;
using System.Collections.Generic;
using TheShop.Contracts;
using TheShop.ExternalServices;
using TheShop.Persistance;

namespace TheShop
{
	internal class Program
	{
		private static void Main(string[] args)
		{
            int buyerId = 10;
            int articleId = 1;
            int maxExpectedPrice = 20;

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
                var article = shopService.OrderArticle(articleId, maxExpectedPrice);
                
				shopService.SellArticle(buyerId, article);

                shopService.DispalyArticle(article);

            }
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}


			Console.ReadKey();
		}
	}
}