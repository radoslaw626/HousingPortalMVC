using System.Collections.Generic;
using HousingPortalMVC.Entities;
using Microsoft.AspNetCore.Identity;

namespace HousingPortalMVC.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            HousingOffers = new List<HousingOffer>();
        }
        public string FullName { get; set; }
        public virtual IList<HousingOffer> HousingOffers { get; set; }

    }
}
