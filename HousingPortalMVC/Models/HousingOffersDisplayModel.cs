using System.Collections.Generic;
using HousingPortalMVC.Dtos;

namespace HousingPortalMVC.Models
{
    public class HousingOffersDisplayModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string ImageFormat { get; set; }
        public string City { get; set; }
        public string SearchString { get; set; }
    }
}
