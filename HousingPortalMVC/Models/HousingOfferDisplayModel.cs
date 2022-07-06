using System.Security.AccessControl;

namespace HousingPortalMVC.Models
{
    public class HousingOfferDisplayModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string ImageFormat { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }

    }
}
