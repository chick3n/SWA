using System;
using System.Collections.Generic;
using System.Text;

namespace SWA.Domain.Entities
{
    public class DiscoveryObject
    {
        public int Id { get; set; }
        public SiteCollection SiteCollection { get; set; }
        public int SiteCollectionId { get; set; }
        public string SiteName { get; set; }
        public string StaticName { get; set; }
        public string Url { get; set; }
        public Enums.DiscoveryType DiscoveryType { get; set; }
        public DateTime? LastSeen { get; set; }
        public bool Enabled { get; set; }
    }
}
