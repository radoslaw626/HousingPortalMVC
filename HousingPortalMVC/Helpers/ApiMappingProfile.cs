using AutoMapper;
using HousingPortalMVC.Dtos;
using HousingPortalMVC.Entities;
using HousingPortalMVC.Models;

namespace HousingPortalMVC.Helpers
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<HousingOffer, HousingOfferDto>().ReverseMap();
            CreateMap<HousingOfferImage, HousingOfferImageDto>().ReverseMap();
        }
    }
}
