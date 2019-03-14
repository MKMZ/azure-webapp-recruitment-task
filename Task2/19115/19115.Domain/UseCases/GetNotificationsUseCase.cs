using _19115.Domain.Entities;
using _19115.Domain.Ports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _19115.Domain.UseCases
{
    public interface IGetNotificationsUseCase
    {
        Task<IList<Notification>> Run();
    }

    public class GetNotificationsUseCase : IGetNotificationsUseCase
    {
        private readonly INotificationFetcherPort _notificationFetcherPort;
        private readonly INotificationMapperPort _notificationMapperPort;

        public GetNotificationsUseCase(
            INotificationFetcherPort notificationFetcherPort,
            INotificationMapperPort notificationMapperPort)
        {
            _notificationFetcherPort = notificationFetcherPort;
            _notificationMapperPort = notificationMapperPort;
        }

        public async Task<IList<Notification>> Run()
        {
            var rawNotificationList = await _notificationFetcherPort.FetchRawNotificationList();
            return await _notificationMapperPort.MapList(rawNotificationList);
        }
    }
}
