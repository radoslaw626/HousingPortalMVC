using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using AutoMapper;
using HousingPortalMVC.Data;
using HousingPortalMVC.Dtos;
using HousingPortalMVC.Entities;
using HousingPortalMVC.IServices;
using HousingPortalMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace HousingPortalMVC.Controllers
{
    public class HousingOffersController : Controller
    {
        private readonly IHousingOffersService _offersService;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public HousingOffersController(IHousingOffersService offersService, IMapper mapper, ApplicationDbContext context)
        {
            _offersService = offersService;
            _mapper = mapper;
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index(string searchString)
        {
            if (searchString != null)
            {
                var allOffers = _offersService.GetAllByCity(searchString);
                var model = new List<HousingOffersDisplayModel>();

                foreach (var item in allOffers)
                {
                    var modelElement = new HousingOffersDisplayModel();
                    modelElement.Id = item.Id;
                    modelElement.Title = item.Title;
                    modelElement.Image = Convert.ToBase64String(item.Images.First().Image);
                    modelElement.ImageFormat = item.Images.First().ImageFormat;
                    modelElement.City = item.City;
                    model.Add(modelElement);
                }
                return View(model);
            }
            else
            {
                var allOffers = _offersService.GetAll();
                var model = new List<HousingOffersDisplayModel>();

                foreach (var item in allOffers)
                {
                    var modelElement = new HousingOffersDisplayModel();
                    modelElement.Id = item.Id;
                    modelElement.Title = item.Title;
                    modelElement.Image = Convert.ToBase64String(item.Images.First().Image);
                    modelElement.ImageFormat = item.Images.First().ImageFormat;
                    modelElement.City = item.City;
                    model.Add(modelElement);
                }
                return View(model);
            }

        }

        [Authorize]
        [HttpGet]
        public IActionResult UserOffers()
        {

            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    var UserId = userIdClaim.Value;
                    var user = _context.Users.FirstOrDefault(x => x.Id == UserId);
                    var allOffers = _offersService.GetAllByUser(user.Id);
                    var model = new List<HousingOffersDisplayModel>();

                    foreach (var item in allOffers)
                    {
                        var modelElement = new HousingOffersDisplayModel();
                        modelElement.Id = item.Id;
                        modelElement.Title = item.Title;
                        modelElement.Image = Convert.ToBase64String(item.Images.First().Image);
                        modelElement.ImageFormat = item.Images.First().ImageFormat;
                        modelElement.City = item.City;
                        model.Add(modelElement);
                    }
                    return View(model);
                }
                return View(new List<HousingOffersDisplayModel>());
            }
            return View(new List<HousingOffersDisplayModel>());

        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Offer(long offerId)
        {
            var offer = _offersService.Get(offerId);
            var model = new HousingOfferDisplayModel
            {
                Id = offer.Id,
                City = offer.City,
                ImageFormat = offer.Images.First().ImageFormat,
                Image = Convert.ToBase64String(offer.Images.First().Image),
                Title = offer.Title,
                Description = offer.Description,
                PhoneNumber = offer.PhoneNumber
            };
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Modify(long offerId)
        {
            var offer = _offersService.Get(offerId);
            var model = new HousingOfferDisplayModel
            {
                Id = offer.Id,
                City = offer.City,
                ImageFormat = offer.Images.First().ImageFormat,
                Image = Convert.ToBase64String(offer.Images.First().Image),
                Title = offer.Title,
                Description = offer.Description,
                PhoneNumber = offer.PhoneNumber
            };
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult ModifyOffer(HousingOfferDisplayModel data, long offerId)
        {
            var toModify = new HousingOffer()
            {
                Description = data.Description,
                Title = data.Title,
                City = data.City,
                PhoneNumber = data.PhoneNumber
            };
            _offersService.Update(toModify, offerId);
            return RedirectToAction("UserOffers");
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddNew(AddNewHousingOfferModel data)
        {

            return View(data);
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddNewOffer(AddNewHousingOfferModel data)
        {
            var newOffer = _mapper.Map<HousingOffer>(data.HousingOfferDto);
            var memoryStream = new MemoryStream();
            data.Image.CopyTo(memoryStream);
            var image = new HousingOfferImage
            {
                Image = memoryStream.ToArray(),
                ImageFormat = data.Image.ContentType
            };
            newOffer.Images.Add(image);
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    var UserId = userIdClaim.Value;
                    var user = _context.Users.FirstOrDefault(x => x.Id == UserId);
                    newOffer.User = user;
                }
            }
            _offersService.Add(newOffer);
            var returnData = new AddNewHousingOfferModel
            {
                Notification = "Added successfully"
            };
            return RedirectToAction("AddNew", returnData);
        }

        [HttpGet]
        public IActionResult Delete(long offerId)
        {
            _offersService.Delete(offerId);
            return RedirectToAction("UserOffers");
        }
    }
}
