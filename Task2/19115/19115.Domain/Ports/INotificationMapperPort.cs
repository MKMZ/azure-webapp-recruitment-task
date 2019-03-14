using _19115.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _19115.Domain.Ports
{
    public interface INotificationMapperPort
    {
        Task<IList<Notification>> MapList(IList<RawNotification> rawNotificationList);
    }
}
