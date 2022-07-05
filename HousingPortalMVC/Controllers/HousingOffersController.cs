using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using AutoMapper;
using HousingPortalMVC.Dtos;
using HousingPortalMVC.Entities;
using HousingPortalMVC.IServices;
using HousingPortalMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HousingPortalMVC.Controllers
{
    public class HousingOffersController : Controller
    {
        private readonly IHousingOffersService _offersService;
        private readonly IMapper _mapper;

        public HousingOffersController(IHousingOffersService offersService, IMapper mapper)
        {
            _offersService = offersService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var allOffers = _offersService.GetAll();
            var model = new List<HousingOffersDisplayModel>();
            var modelElement = new HousingOffersDisplayModel();
            foreach (var item in allOffers)
            {
                modelElement.Title=item.Title;
                modelElement.Image = Convert.ToBase64String(item.Images.First().Image);
                modelElement.ImageFormat = item.Images.First().ImageFormat;
                model.Add(modelElement);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AddNew(AddNewHousingOfferModel data)
        {
            return View(data);
        }

        [HttpPost]
        public IActionResult AddNewOffer(AddNewHousingOfferModel data)
        {
            var newOffer = _mapper.Map<HousingOffer>(data.HousingOfferDto);
            var memoryStream = new MemoryStream();
            data.Image.CopyTo(memoryStream);
            var image = new HousingOfferImage();
            image.Image = memoryStream.ToArray();
            image.ImageFormat = data.Image.ContentType;
            newOffer.Images.Add(image);
            _offersService.Add(newOffer);
            var returnData = new AddNewHousingOfferModel();
            returnData.Notification = "Added successfully";
            return RedirectToAction("AddNew", returnData);
        }
    }
} 
