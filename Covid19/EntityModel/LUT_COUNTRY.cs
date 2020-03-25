using System;
using System.Collections.Generic;

namespace Covid19.EntityModel
{
    public partial class LUT_COUNTRY
    {
        public LUT_COUNTRY()
        {
            COVID_HEALTHCHECKTRAVEL_IN_14_DAYS_COUNTRYNavigation = new HashSet<COVID_HEALTHCHECK>();
            COVID_HEALTHCHECKTRAVEL_IN_14_DAYS_COUNTRY_OTHERNavigation = new HashSet<COVID_HEALTHCHECK>();
        }

        public int ID { get; set; }
        public string COUNTRY_CODE { get; set; }
        public string COUNTRY_SH_CODE { get; set; }
        public string COUNTRY_NAME { get; set; }
        public string COUNTRY_NAMT { get; set; }
        public bool? DISPLAY_FLAG { get; set; }
        public bool? WATCH_OUT_FLAG { get; set; }

        public virtual ICollection<COVID_HEALTHCHECK> COVID_HEALTHCHECKTRAVEL_IN_14_DAYS_COUNTRYNavigation { get; set; }
        public virtual ICollection<COVID_HEALTHCHECK> COVID_HEALTHCHECKTRAVEL_IN_14_DAYS_COUNTRY_OTHERNavigation { get; set; }
    }
}
