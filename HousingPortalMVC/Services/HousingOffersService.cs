using System.Collections.Generic;
using HousingPortalMVC.Data;
using HousingPortalMVC.Entities;
using HousingPortalMVC.IServices;
using Microsoft.EntityFrameworkCore;

namespace HousingPortalMVC.Services
{
    public class HousingOffersService : IHousingOffersService
    {
        private readonly ApplicationDbContext _context;

        public HousingOffersService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<HousingOffer> GetAll()
        {
            return _context.HousingOffers.Include(x => x.Images);
        }

        public IEnumerable<HousingOffer> GetAllByCity(string city)
        {
            throw new System.NotImplementedException();
        }

        public HousingOffer Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(HousingOffer offer)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(HousingOffer offer)
        {
            throw new System.NotImplementedException();
        }

        public void Add(HousingOffer offer)
        {
            _context.HousingOffers.Add(offer);
            _context.SaveChanges();
        }
    }
}
