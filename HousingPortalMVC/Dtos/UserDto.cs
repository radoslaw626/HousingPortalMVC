using System.Collections.Generic;
using HousingPortalMVC.Entities;
using Microsoft.AspNetCore.Identity;

namespace HousingPortalMVC.Dtos
{
    public class UserDto : IdentityUser
    {
        public UserDto()
        {
            HousingOffers = new List<HousingOffer>();
        }
        public string FullName { get; set; }
        public virtual IList<HousingOffer> HousingOffers { get; set; }

    }
}
