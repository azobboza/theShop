using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Contracts;
using TheShop.Persistance;

namespace TheShop
{
    public class DisplayArticleTask : ITask
    {
        public int Id { get; set; }
        public DisplayArticleTask(int id)
        {
            Id = id;
        }
        public void Execute()
        {
            var article = InMemoryDatabase.GetById(Id);
            if (article == null)
                throw new InvalidOperationException("No such article.");

            Console.WriteLine("Found article with ID: " + article.Id);
        }
    }
}
