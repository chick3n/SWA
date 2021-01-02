using SWA.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWA.Application.SiteCollections.Queries.GetSiteCollections
{
    public class SiteCollectionsDto : IMapFrom<Domain.Entities.SiteCollection>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Domain.Enums.SharePointType SharepointType { get; set; }
        
    }
}
