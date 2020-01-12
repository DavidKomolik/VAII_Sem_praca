using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semestralna_praca_VAII.Data;
using Microsoft.AspNetCore.Identity;

namespace Semestralna_praca_VAII.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignInManager<IdentityUser> _signInManager;

        public EventController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _signInManager = signInManager;
        }

        public IActionResult EventDetail(int ID)
        {
            var Event = _context.Event.Where(a => a.ID == ID).FirstOrDefault();
            return View(Event);
        }

        public IActionResult Vloz(int ID)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var user = _context.CommonUser.Include(b => b.userCart)
                                          .ThenInclude(c => c.eventList)
                                          .Where(a => a.Id == userId).FirstOrDefault();

            var Event = _context.Event.Where(a => a.ID == ID).FirstOrDefault();
            bool added = false;
            for (int i = 0; i < user.userCart.eventList.Count; i++)
            {
                if (Event.ID == user.userCart.eventList[i].addedItemID)
                {
                    user.userCart.eventList[i].amount++;
                    added = true;
                }
            } 
            if(!added)
            {
                var cartItem = new Models.CartItem
                            {
                                addedItem = Event,
                                amount = 1,
                                price = Event.price,
                                addedItemID = Event.ID
                            };
                user.userCart.eventList.Add(cartItem);
            }
            _context.SaveChanges();

            return RedirectToAction("Cart", "User", user.userCart);
        }
        [HttpPost]
        public IActionResult Price(Models.Event e)
        {
            var eve =_context.Event.Where(a => a.ID == e.ID).FirstOrDefault();

            if (User.IsInRole("Admin"))
            {
                eve.price = Convert.ToDouble(e.price);

                _context.SaveChanges();
            }
            return View("EventDetail",eve);
        }




    }
}