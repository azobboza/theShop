﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.Entities
{
    public class Article
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }
        public bool IsSold { get; set; }

        public DateTime SoldDate { get; set; }
        public int BuyerId { get; set; }
    }
}