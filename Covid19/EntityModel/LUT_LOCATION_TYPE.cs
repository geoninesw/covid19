using System;
using System.Collections.Generic;

namespace Covid19.EntityModel
{
    public partial class LUT_LOCATION_TYPE
    {
        public LUT_LOCATION_TYPE()
        {
            COVID_HEALTHCHECK = new HashSet<COVID_HEALTHCHECK>();
        }

        public int ID { get; set; }
        public string SHORT_DESCR { get; set; }
        public string DESCR { get; set; }

        public virtual ICollection<COVID_HEALTHCHECK> COVID_HEALTHCHECK { get; set; }
    }
}
