using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HousingPortalMVC.Entities
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
