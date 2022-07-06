using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<HousingOffer> GetAllByUser(string userId)
        {
            var user = _context.Users.Include(x => x.HousingOffers).FirstOrDefault(y => y.Id == userId);
            if (user != null)
                return _context.HousingOffers.Include(x => x.Images).Where(y => y.User == user);
            else
                return new List<HousingOffer>();
        }

        public IEnumerable<HousingOffer> GetAllByCity(string city)
        {
            return _context.HousingOffers.Include(x => x.Images).Where(y => y.City.Contains(city));

        }

        public HousingOffer Get(long id)
        {
            return _context.HousingOffers.Include(y=>y.Images).FirstOrDefault(x => x.Id == id);
        }

        public void Update(HousingOffer offer, long offerId)
        {
            var offerToModify = _context.HousingOffers.FirstOrDefault(x => x.Id == offerId);
            if (offerToModify != null)
            {
                offerToModify.City=offer.City;
                offerToModify.Description=offer.Description;
                offerToModify.PhoneNumber=offer.PhoneNumber;
                offerToModify.Title=offer.Title;
                _context.SaveChanges();
            }
        }

        public void Delete(long offerId)
        {
            var offer=_context.HousingOffers.Include(y=>y.Images).Include(z=>z.User).FirstOrDefault(x => x.Id == offerId);
            if (offer != null)
            {
                _context.HousingOffers.Remove(offer);
                _context.SaveChanges();
            }

        }

        public void Add(HousingOffer offer)
        {
            _context.HousingOffers.Add(offer);
            _context.SaveChanges();
        }
    }
}
