using System.Collections.Generic;

namespace HousingPortalMVC.Entities
{
    public class HousingOffer
    {
        public HousingOffer()
        {
            Images = new List<HousingOfferImage>();
        }
        public long Id { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public virtual IList<HousingOfferImage> Images { get; set; }
        public User User { get; set; }
    }
}
