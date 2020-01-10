using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semestralna_praca_VAII.Data;

namespace Semestralna_praca_VAII.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EventController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult EventDetail(int ID)
        {
            var Event = _context.Event.Where(a => a.ID == ID).FirstOrDefault();
            return View(Event);
        }

        public IActionResult Vloz(int ID)
        {
            //todo aby sa mi ukazalo vloz iba ked som prihlaseny
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            var user = _context.CommonUser.Include(b => b.userCart)
                                          .ThenInclude(c => c.eventList)
                                          .Where(a => a.Id == userId).FirstOrDefault();

            var Event = _context.Event.Where(a => a.ID == ID).FirstOrDefault();
            var cartItem = new Models.CartItem
            {
                addedItem = Event,
                amount = 1,
                price = Event.price
            };

            user.userCart.eventList.Add(cartItem);

            _context.SaveChanges();

            return View();
        }


    }
}