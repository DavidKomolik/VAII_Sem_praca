using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semestralna_praca_VAII.Models
{
    public class Purchase
    {
        public Event boughtEvent { get; set; }
        public int amount { get; set; }
        public double price { get; set; }
    }
}
