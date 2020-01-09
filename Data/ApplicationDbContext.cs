using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Semestralna_praca_VAII.Models;

namespace Semestralna_praca_VAII.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Semestralna_praca_VAII.Models.Event> Event { get; set; }
        public virtual DbSet<Semestralna_praca_VAII.Models.Cart> Cart { get; set; }
        public virtual DbSet<Semestralna_praca_VAII.Models.CartItem> CartItem { get; set; }
        public virtual DbSet<Semestralna_praca_VAII.Models.CommonUser> CommonUser { get; set; }
        public virtual DbSet<Semestralna_praca_VAII.Models.ShoppingHistory> ShoppingHistory { get; set; }
    }
}
