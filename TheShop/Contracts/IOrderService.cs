using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Entities;

namespace TheShop.Contracts
{
    public interface IOrderService
    {
        Article Order(int id, double maxExpectedPrice);
    }
}
