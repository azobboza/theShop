using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Contracts;
using TheShop.Entities;

namespace TheShop.Persistance
{
    public class DatabaseDriver : IDatabaseDriver
    {
        private readonly List<Article> _articles;
        public DatabaseDriver()
        {
            _articles = new List<Article>();
        }
        public Article GetById(int id)
        {
            return _articles.Single(x => x.Id == id);
        }

        public void Save(Article article)
        {
            _articles.Add(article);
        }
    }
}
