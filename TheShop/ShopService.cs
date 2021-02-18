using System;
using System.Collections.Generic;
using TheShop.Contracts;
using TheShop.Entities;

namespace TheShop
{
	public class ShopService : IShopService
	{
        private readonly IOrderService _orderService;
        private readonly IDatabaseDriver _databaseDriver;
		
		public ShopService(IOrderService orderService, IDatabaseDriver databaseDriver)
		{
            _orderService = orderService ?? throw new ArgumentNullException("ShopService constructor: IOrderService type is null.");
            _databaseDriver = databaseDriver ?? throw new ArgumentNullException("ShopService constructor: IDatabaseDriver type is null.");
		}

        public Article OrderArticle(int id, double maxExpectedPrice)
        {
            return _orderService.Order(id, maxExpectedPrice);
        }

        public void SellArticle(int buyerId, Article article)
        {
            if (article == null)
            {
                throw new Exception("ShopService.SellArticle() method. No Article to sell.");
            }

            article.IsSold = true;
            article.SoldDate = DateTime.Now;
            article.BuyerId = buyerId;

            _databaseDriver.Save(article);
        }

		public void DispalyArticle(Article article)
		{
            var searchingArticle = _databaseDriver.GetById(article.Id);

            if (searchingArticle == null)
            {
                throw new Exception($"Article with id {article.Id} not found.");
            }

            Console.WriteLine("Found article with ID: " + article.Id);
        }
    }
}
