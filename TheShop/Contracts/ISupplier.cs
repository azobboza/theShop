﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Entities;

namespace TheShop.Contracts
{
    public interface ISupplier
    {
        Article GetArticle(int id);
    }
}
