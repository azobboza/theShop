using System;
using TheShop.Contracts;
using TheShop.Entities;

namespace TheShop
{
    public class Service : IService
    {
        private readonly IShopService _shopService;
        public Service(IShopService shopService)
        {
            _shopService = shopService ?? throw new ArgumentNullException("Service constructor: IShopService type is null.");
        }
        public void Run(int articleId, Buyer buyer)
        {
            var article = _shopService.OrderArticle(articleId, buyer.MaxExpectedPrice);

            _shopService.SellArticle(buyer.Id, article);

            _shopService.DispalyArticle(article);
        }
    }
}
