using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BusTrackerBackend
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Bus, BusDto>()
            .ForMember(c => c.PlateNumberAndModel,
            opt => opt.MapFrom(x => string.Join(' ', x.PlateNumber, x.Model)));
            CreateMap<CustomerBooking, CustomerBookingDto>();
            CreateMap<DriverTicket, DriverTicketDto>();

            CreateMap<BusForCreationDto, Bus>();
            CreateMap<CustomerBookingForCreationDto, CustomerBooking>();
            CreateMap<DriverTicketForCreationDto, DriverTicket>();

            CreateMap<BusForUpdateDto, Bus>();
            CreateMap<CustomerBookingForUpdateDto, CustomerBooking>();
            CreateMap<DriverTicketForUpdateDto, DriverTicket>();

            CreateMap<UserForRegistrationDto, User>();

        }
    }

}
