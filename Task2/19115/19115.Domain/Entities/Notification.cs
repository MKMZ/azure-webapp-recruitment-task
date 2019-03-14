using System;

namespace _19115.Domain.Entities
{
    public class Notification
    {
        public string Category { get; set; }
        public string City { get; set; }
        public string Subcategory { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string ApartmentNumber { get; set; }
        public string Type { get; set; }
        public string Event { get; set; }
        public string CurrentStatus { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
