using TheShop.Entities;

namespace TheShop.Contracts
{
    public interface IService
    {
        void Run(int articleId, Buyer buyer);
    }
}
