using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.Contracts;
using TheShop.Entities;
using TheShop.LoggerService;

namespace TheShop
{
	public class ShopService : IShopService
	{
        private readonly List<ISupplier> _suppliers;
        private readonly IDatabaseDriver _databaseDriver;
		
		public ShopService(List<ISupplier> suppliers, IDatabaseDriver databaseDriver)
		{
            _suppliers = suppliers;
            _databaseDriver = databaseDriver;
		}

        public Article OrderArticle(int id, int maxExpectedPrice)
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
                throw new ArgumentNullException("ShopService.SellArticle() method. Given Article variable is null.");
            }

            article.IsSold = true;
            article.SoldDate = DateTime.Now;
            article.BuyerId = buyerId;

            try
            {
                _databaseDriver.Save(article);
                LoggerManager.Info("Article with id=" + article.Id + " is sold.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not save article with id={article.Id}. Exception: {ex}");
            }
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
