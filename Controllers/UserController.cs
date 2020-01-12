using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semestralna_praca_VAII.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Semestralna_praca_VAII.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignInManager<IdentityUser> _signInManager;
        public UserController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _signInManager = signInManager;
        }
        public IActionResult Cart()
        {
            if (_signInManager.IsSignedIn(User))
            {


                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

                var user = _context.CommonUser.Include(b => b.userCart)
                                              .ThenInclude(c => c.eventList)
                                              //.Include(a => a.shoppingHistory)
                                              //.ThenInclude(c => c.purchases)
                                              .Where(a => a.Id == userId).FirstOrDefault();
                if (user.userCart == null)
                {
                    user.userCart = new Models.Cart();
                    user.userCart.eventList = new List<Models.CartItem>();
                }

                foreach (var item in user.userCart.eventList)
                {
                    item.addedItem = _context.Event.Where(a => item.addedItemID == a.ID).FirstOrDefault();
                }

                return View(user.userCart);
            } else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult getShoppingHistory(string ID)
        {

            // OBSOLETE
            var shoppingHistory = _context.CommonUser.Include(a => a.shoppingHistory)
                                          .Where(a => a.Id == ID).FirstOrDefault().shoppingHistory;
            return View(shoppingHistory);
        }
        [HttpPost]
        public IActionResult Delete(Models.Cart c, int cart, int id)
        {
            var realCart = _context.Cart.Include(a => a.eventList)
                .Where(a => a.ID == cart).FirstOrDefault();

            int i = 0;
            foreach (var item in realCart.eventList)
            {
                if (item.ID == id)
                {
                    _context.CartItem.Remove(item);
                    break;
                }
                i++;
            }
            _context.SaveChanges();
            return RedirectToAction("Cart");
        }
        [HttpGet]
        public IActionResult Checkout(int ID)
        {
            if (ID == 0)
            {
                return View();
            }

            var realCart = _context.Cart.Include(a => a.eventList)
               .Where(a => a.ID == ID).FirstOrDefault();

            foreach (var item in realCart.eventList)
            {
                item.addedItem = _context.Event.Where(a => item.addedItemID == a.ID).FirstOrDefault();
            }
            return View(realCart);
        }
    }
}



