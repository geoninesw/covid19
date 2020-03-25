using System;
using System.Collections.Generic;

namespace Covid19.EntityModel
{
    public partial class COVID_HEALTHCHECK_COUNTRY
    {
        public int ID { get; set; }
        public int REPORTER_ID { get; set; }
        public int? COUNTRY_ID { get; set; }
    }
}
