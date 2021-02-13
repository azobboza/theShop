using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Contracts;
using TheShop.Entities;

namespace TheShop.Persistance
{
    public class Supplier1 : ISupplier
    {
        public bool ArticleInInventory(int id)
        {
            return true;
        }

        public Article GetArticle(int id)
        {
            return new Article()
            {
                Id = 1,
                Name = "Article from supplier1",
                Price = 458
            };
        }
    }
}
