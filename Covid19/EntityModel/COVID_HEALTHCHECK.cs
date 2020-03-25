using System;
using System.Collections.Generic;

namespace Covid19.EntityModel
{
    public partial class COVID_HEALTHCHECK
    {
        public int ID { get; set; }
        public bool? TRAVEL_IN_14_DAYS_FLAG { get; set; }
        public int? TRAVEL_IN_14_DAYS_COUNTRY { get; set; }
        public bool? CLOSE_TO_FOREIGNER_FLAG { get; set; }
        public int? OCCUPATION_ID { get; set; }
        public bool? CLOSE_TO_PATIENT_FLAG { get; set; }
        public bool? TRAVEL_IN_14_DAYS_OTHER_FLAG { get; set; }
        public int? TRAVEL_IN_14_DAYS_COUNTRY_OTHER { get; set; }
        public bool? MEDICAL_STAFF_FLAG { get; set; }
        public int? AGE { get; set; }
        public long? AMPHUR_ID { get; set; }
        public bool? FRIENT_HAS_FLU_FLAG { get; set; }
        public int? LOCATION_TYPE_ID { get; set; }
        public DateTime? CREATED_DT { get; set; }

        public virtual LUT_PROVINCE AMPHUR_ { get; set; }
        public virtual LUT_LOCATION_TYPE LOCATION_TYPE_ { get; set; }
        public virtual LUT_OCCUPATION OCCUPATION_ { get; set; }
        public virtual LUT_COUNTRY TRAVEL_IN_14_DAYS_COUNTRYNavigation { get; set; }
        public virtual LUT_COUNTRY TRAVEL_IN_14_DAYS_COUNTRY_OTHERNavigation { get; set; }
    }
}
