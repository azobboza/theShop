using System.Collections.Generic;
using System.Linq;
using TheShop.Contracts;
using TheShop.Entities;

namespace TheShop.Persistance
{
    public class InMemoryDatabase 
    {
        private static List<Article> _articles = new List<Article>();
        
        public static Article GetById(int id)
        {
            return _articles.Single(x => x.Id == id);
        }

        public static void Save(Article article)
        {
            _articles.Add(article);
        }
    }
}
