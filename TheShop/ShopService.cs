using System;
using System.Collections.Generic;
using TheShop.Contracts;
using TheShop.Entities;

namespace TheShop
{
	public class ShopService : IShopService
	{
        private readonly List<ISupplier> _suppliers;
        private readonly IDatabaseDriver _databaseDriver;
		
		public ShopService(List<ISupplier> suppliers, IDatabaseDriver databaseDriver)
		{
            _suppliers = suppliers ?? throw new ArgumentNullException("ShopService constructor: List<ISupplier> type is null.");
            _databaseDriver = databaseDriver ?? throw new ArgumentNullException("ShopService constructor: IDatabaseDriver type is null.");
		}

        public Article OrderArticle(int id, decimal maxExpectedPrice)
        {
            foreach (var supplier in _suppliers)
            {
                var article = supplier.GetArticle(id);
                if (article != null)
                {
                    if (article.Price < maxExpectedPrice)
                        return article;
                }
            }
            return null;
        }

        public void SellArticle(int buyerId, Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException("ShopService.SellArticle() method. No Article to sell.");
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
