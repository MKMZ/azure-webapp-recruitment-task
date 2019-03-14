using System.Collections.Generic;
using System.Threading.Tasks;
using _19115.Domain.Entities;
using _19115.Domain.Ports;
using AutoMapper;
using Newtonsoft.Json;

namespace _19115.Adapters
{
    public class NotificationMapperAdapter : INotificationMapperPort
    {
        private readonly IMapper _mapper;

        public NotificationMapperAdapter()
        {
            _mapper = new MapperConfiguration(cfg => cfg
                .CreateMap<RawNotification, Notification>()
                .ForMember(dest => dest.ApartmentNumber, opt => opt.MapFrom(src => src.AparmentNumber))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.NotificationType))
                ).CreateMapper();
        }

        public Task<IList<Notification>> MapList(IList<RawNotification> rawNotificationList) =>
            Task.FromResult(_mapper.Map<IList<RawNotification>, IList<Notification>>(rawNotificationList));
    }
}
