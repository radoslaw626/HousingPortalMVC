using HousingPortalMVC.Dtos;
using HousingPortalMVC.Entities;
using Microsoft.AspNetCore.Http;

namespace HousingPortalMVC.Models
{
    public class AddNewHousingOfferModel
    {
        public HousingOfferDto HousingOfferDto { get; set; }
        public string Notification { get; set; }
        public IFormFile Image { get; set; }
    }
}
