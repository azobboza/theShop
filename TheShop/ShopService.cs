using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.Contracts;
using TheShop.Entities;

namespace TheShop
{
	public class ShopService
	{
		private DatabaseDriver DatabaseDriver;
		private Logger logger;

		private readonly List<ISupplier> _suppliers;
		
		public ShopService()
		{
            _suppliers = new List<ISupplier>();

            DatabaseDriver = new DatabaseDriver();
			logger = new Logger();
            
		}

        public Article Order(int id, int maxExpectedPrice)
        {
            foreach (var supplier in _suppliers)
            {
                if (supplier.ArticleInInventory(id))
                {
                    var articleX = supplier.GetArticle(id);
                    if (articleX.Price < maxExpectedPrice)
                        return articleX;
                }
            }
            return null;
        }

        public void Order(int buyerId, Article article)
        {
            if (article == null)
            {
                throw new Exception("Could not order article");
            }

            article.IsSold = true;
            article.SoldDate = DateTime.Now;
            article.BuyerId = buyerId;

            try
            {
                DatabaseDriver.Save(article);
                logger.Info("Article with id=" + article.Id + " is sold.");
            }
            catch (Exception ex)
            {
                logger.Error("Could not save article with id=" + article.Id);
                throw new Exception("Could not save article with id. ");
            }
        }

		public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
		{
			#region ordering article

			//Article article = null;
			//Article tempArticle = null;
			//var articleExists = Supplier1.ArticleInInventory(id);
			//if (articleExists)
			//{
			//	tempArticle = Supplier1.GetArticle(id);
			//	if (maxExpectedPrice < tempArticle.ArticlePrice)
			//	{
			//		articleExists = Supplier2.ArticleInInventory(id);
			//		if (articleExists)
			//		{
			//			tempArticle = Supplier2.GetArticle(id);
			//			if (maxExpectedPrice < tempArticle.ArticlePrice)
			//			{
			//				articleExists = Supplier3.ArticleInInventory(id);
			//				if (articleExists)
			//				{
			//					tempArticle = Supplier3.GetArticle(id);
			//					if (maxExpectedPrice < tempArticle.ArticlePrice)
			//					{
			//						article = tempArticle;
			//					}
			//				}
			//			}
			//		}
			//	}
			//}

   //         article = tempArticle;
			#endregion

			#region selling article

			//if (article == null)
			//{
			//	throw new Exception("Could not order article");
			//}

			//logger.Debug("Trying to sell article with id=" + id);

			//article.IsSold = true;
			//article.SoldDate = DateTime.Now;
			//article.BuyerUserId = buyerId;
			
			//try
			//{
			//	DatabaseDriver.Save(article);
			//	logger.Info("Article with id=" + id + " is sold.");
			//}
			//catch (ArgumentNullException ex)
			//{
			//	logger.Error("Could not save article with id=" + id);
			//	throw new Exception("Could not save article with id");
			//}
			//catch (Exception)
			//{
			//}

			#endregion
		}

		public Article GetById(int id)
		{
			return DatabaseDriver.GetById(id);
		}
	}

	//in memory implementation
	public class DatabaseDriver
	{
		private List<Article> _articles = new List<Article>();

		public Article GetById(int id)
		{
            return _articles.Single(x => x.Id == id);
		}

		public void Save(Article article)
		{
			_articles.Add(article);
		}
	}

	public class Logger
	{
		public void Info(string message)
		{
			Console.WriteLine("Info: " + message);
		}

		public void Error(string message)
		{
			Console.WriteLine("Error: " + message);
		}

		public void Debug(string message)
		{
			Console.WriteLine("Debug: " + message);
		}
	}
}
