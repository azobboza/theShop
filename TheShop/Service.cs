using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Contracts;
using TheShop.Entities;
using TheShop.LoggerService;

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
