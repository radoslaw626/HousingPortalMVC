using System.Collections.Generic;
using HousingPortalMVC.Entities;
using Microsoft.AspNetCore.Http;
using System.Web;

namespace HousingPortalMVC.IServices
{
    public interface IHousingOffersService
    {
        IEnumerable<HousingOffer> GetAll();
        IEnumerable<HousingOffer> GetAllByUser(string UserId);
        IEnumerable<HousingOffer> GetAllByCity(string city);
        HousingOffer Get(long id);
        void Update(HousingOffer offer, long offerId);
        void Delete(long offerId);
        void Add(HousingOffer offer);
    }
}
