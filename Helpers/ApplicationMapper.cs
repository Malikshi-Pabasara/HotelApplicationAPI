using AutoMapper;
using HotelApplication.Data;
using HotelApplication.Models;

namespace HotelApplication.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Contacts, ContactModel>().ReverseMap();
            CreateMap<Feature, FeatureModel>().ReverseMap();
            CreateMap<Price, PriceModel>().ReverseMap();
            CreateMap<PropertyInfo, PropertyModel>().ReverseMap();
            CreateMap<Reservation, ReservationModel>().ReverseMap();
            CreateMap<Room, RoomModel>().ReverseMap();
        }
    }
}
