using TheShop.Entities;

namespace TheShop.Contracts
{
    public interface IShopService
    {
        Article OrderArticle(int id, double maxExpectedPrice);
        void SellArticle(int buyerId, Article article);
        void DispalyArticle(Article article);
    }
}
