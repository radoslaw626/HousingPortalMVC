using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using HousingPortalMVC.Entities;

namespace HousingPortalMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<HousingOffer> HousingOffers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<HousingOfferImage> HousingOfferImages { get; set; }

    }
}
