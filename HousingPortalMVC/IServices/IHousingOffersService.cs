using System.Collections.Generic;
using HousingPortalMVC.Entities;
using Microsoft.AspNetCore.Http;
using System.Web;

namespace HousingPortalMVC.IServices
{
    public interface IHousingOffersService
    {
        IEnumerable<HousingOffer> GetAll();
        IEnumerable<HousingOffer> GetAllByCity(string city);
        HousingOffer Get(string id);
        void Update(HousingOffer offer);
        void Delete(HousingOffer offer);
        void Add(HousingOffer offer);
    }
}
