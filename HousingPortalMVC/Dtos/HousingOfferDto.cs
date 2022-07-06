using System.Collections.Generic;
using HousingPortalMVC.Entities;

namespace HousingPortalMVC.Dtos
{
    public class HousingOfferDto
    {
        public HousingOfferDto()
        {
            Images = new List<HousingOfferImageDto>();
        }
        public string Id { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public virtual IList<HousingOfferImageDto> Images { get; set; }
        public User User { get; set; }
    }
}
