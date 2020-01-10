using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Semestralna_praca_VAII.Models
{
    public class CommonUser : IdentityUser
    {
        public Cart userCart { get; set; }
        public ShoppingHistory shoppingHistory { get; set; }
    }
}
