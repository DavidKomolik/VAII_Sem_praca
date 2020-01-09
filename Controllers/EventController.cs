using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Semestralna_praca_VAII.Data;

namespace Semestralna_praca_VAII.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult EventDetail(int ID)
        {
            var Event = _context.Event.Where(a => a.ID == ID).FirstOrDefault();
            return View(Event);
        }

    }
}