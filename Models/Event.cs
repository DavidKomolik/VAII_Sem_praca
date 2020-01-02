using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Semestralna_praca_VAII.Models
{
    public class Event
    {
        [Required]
        public string name;
        [Required]
        public DateTime date;
        [Required]
        public string description;
        public int capacity;
        [Required]
        public double price;
        [Required]
        public string location;


    }
}
