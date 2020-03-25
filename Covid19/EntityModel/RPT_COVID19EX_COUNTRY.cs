using System;
using System.Collections.Generic;

namespace Covid19.EntityModel
{
    public partial class RPT_COVID19EX_COUNTRY
    {
        public int ID { get; set; }
        public int REPORTER_ID { get; set; }
        public int? COUNTRY_ID { get; set; }
        public int? PERSON_TYPE_ID { get; set; }

        public virtual RPT_COVID19EX REPORTER_ { get; set; }
    }
}
