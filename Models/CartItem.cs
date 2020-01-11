using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semestralna_praca_VAII.Models
{
    public class CartItem
    {
        public Event addedItem { get; set; }
        public int addedItemID { get; set; }
        public int amount { get; set; }
        public double price { get; set; }
        public int ID { get; set; }
    }
}
