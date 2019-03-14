using _19115.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _19115.Domain.Ports
{
    public interface INotificationFetcherPort
    {
        Task<IList<RawNotification>> FetchRawNotificationList();
    }
}
