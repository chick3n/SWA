using System;
using System.Collections.Generic;
using System.Text;

namespace SWA.Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
