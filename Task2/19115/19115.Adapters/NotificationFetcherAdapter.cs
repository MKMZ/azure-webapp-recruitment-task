using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using _19115.Domain.Entities;
using _19115.Domain.Ports;
using Flurl;
using Flurl.Http;

namespace _19115.Adapters
{
    public class NotificationFetcherAdapter : INotificationFetcherPort
    {
        private readonly string WarsawApiUrl = ConfigurationManager.AppSettings["WarsawApiUrl"];
        private readonly string ApiKey = ConfigurationManager.AppSettings["ApiKey"];
        private readonly string ResourceId = ConfigurationManager.AppSettings["WarsawResourceId"];

        private readonly object[] GetNotificationsPath = { "api", "action", "19115store_getNotifications" };

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
