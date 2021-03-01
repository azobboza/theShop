using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Contracts;
using TheShop.Entities;
using TheShop.Persistance;

namespace TheShop
{
    public class OrderArticleTask : ITask
    {
        public int ArticleId { get; private set; }
        public double MaxExpectedPrice { get; private set; }
        public int BuyerId { get; private set; }
        private readonly List<ISupplier> _suppliers;
        public OrderArticleTask(int articleId, double maxExpectedPrice, int buyerId, List<ISupplier> suppliers)
        {
            ArticleId = articleId;
            MaxExpectedPrice = maxExpectedPrice;
            BuyerId = buyerId;
            _suppliers = suppliers;
        }
        public void Execute()
        {
            foreach (var supplier in _suppliers)
            {
                var article = supplier.GetArticle(ArticleId);
                if (article != null)
                {
                    if (article.Price < MaxExpectedPrice)
                    {
                        InMemoryDatabase.Save(new Article { Id = ArticleId, IsSold = true, SoldDate = DateTime.Now, BuyerId = BuyerId });
                        return;
                    }
                }
            }
        }
    }
}
