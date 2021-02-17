using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Entities;

namespace TheShop.Contracts
{
    public interface IShopService
    {
        Article OrderArticle(int id, decimal maxExpectedPrice);
        void SellArticle(int buyerId, Article article);
        void DispalyArticle(Article article);
    }
}
