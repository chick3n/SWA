using Microsoft.AspNetCore.Mvc;
using SWA.Application.SiteCollections.Queries.GetSiteCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class SiteCollectionsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<SitesVm>> Get()
        {
            return await Mediator.Send(new GetSiteCollectionsQuery());
        }
    }
}
