﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semestralna_praca_VAII.Models
{
    public class ShoppingHistory
    {
        public List<CartItem> purchases { get; set; }
        public int ID { get; set; }
    }
}
