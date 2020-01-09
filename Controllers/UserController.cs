using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semestralna_praca_VAII.Data;

namespace Semestralna_praca_VAII.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult getCart()
        {
            var cart = _context.CommonUser.Include(a => a.userCart)
                                          .Where(a => a.Id == ID).FirstOrDefault().userCart;
            return View(cart);
        }
        public IActionResult getShoppingHistory(string ID)
        {
            var shoppingHistory = _context.CommonUser.Include(a => a.shoppingHistory)
                                          .Where(a => a.Id == ID).FirstOrDefault().shoppingHistory;
            return View(shoppingHistory);
        }
    }
}