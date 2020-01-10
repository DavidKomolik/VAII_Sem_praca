using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semestralna_praca_VAII.Data;
using System.Security.Claims;

namespace Semestralna_praca_VAII.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Cart()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var user = _context.CommonUser.Include(b => b.userCart)
                                          .ThenInclude(c => c.eventList)
                                          .Include(a => a.shoppingHistory)
                                          .ThenInclude(c => c.purchases)
                                          .Where(a => a.Id == userId).FirstOrDefault();
            if(user.userCart == null)
            {
                user.userCart = new Models.Cart();
                user.userCart.eventList = new List<Models.CartItem>();
            }
            
            return View(user.userCart);
        }
        public IActionResult getShoppingHistory(string ID)
        {
            var shoppingHistory = _context.CommonUser.Include(a => a.shoppingHistory)
                                          .Where(a => a.Id == ID).FirstOrDefault().shoppingHistory;
            return View(shoppingHistory);
        }

    }

}