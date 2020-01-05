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
        public string name { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public string description { get; set; }
        public int capacity { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public string location { get; set; }
        [Required]
        public int ID { get; set; }
        public string imgPath { get; set; }
        public bool isFeatured { get; set; }


    }
}
