using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using _19115.Domain.Entities;
using _19115.Domain.Ports;
using Flurl;
using Flurl.Http;

namespace _19115.Adapters
{
    public class NotificationFetcherAdapter : INotificationFetcherPort
    {
        private readonly string WarsawApiUrl = "https://api.um.warszawa.pl";
        private readonly object[] GetNotificationsPath = { "api", "action", "19115store_getNotifications" };
        private readonly string ApiKey = "ff4f51a0-f7dd-44e7-81d6-f9af77e647b4";
        private readonly string ResourceId = "28dc65ad-fff5-447b-99a3-95b71b4a7d1e";

        public async Task<IList<RawNotification>> FetchRawNotificationList()
        {
            var response = await WarsawApiUrl
                .AppendPathSegments(GetNotificationsPath)
                .SetQueryParams(new
                {
                    id = ResourceId,
                    apikey = ApiKey
                }).GetJsonAsync<WarsawApiResponse>();
            return response
                .Result
                .Result
                .Notifications;
        }

        private class InnerResult
        {
            public IList<RawNotification> Notifications { get; set; }
        }

        private class OuterResult
        {
            public InnerResult Result { get; set; }
        }

        private class WarsawApiResponse
        {
            public OuterResult Result { get; set; }
        }
    }
}
