using SWA.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWA.Domain.Entities
{
    public class SiteCollection : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Enums.SharePointType SharepointType { get; set; }
        public bool Enabled { get; set; }

        public ICollection<DiscoveryObject> DiscoveryObjects { get; set; }
    }
}
