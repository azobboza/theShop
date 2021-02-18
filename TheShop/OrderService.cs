using System;
using System.Collections.Generic;
using TheShop.Contracts;
using TheShop.Entities;

namespace TheShop
{
    public class OrderService : IOrderService
    {
        private readonly List<ISupplier> _suppliers;
        public OrderService(List<ISupplier> suppliers)
        {
            _suppliers = suppliers ?? throw new ArgumentNullException("ShopService constructor: List<ISupplier> type is null.");
        }
        public Article Order(int id, double maxExpectedPrice)
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
    }
}
