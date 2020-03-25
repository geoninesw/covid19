using Covid19.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.ViewModels
{
    public class CovidHealthCheckViewModel
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

        public virtual ICollection<COVID_HEALTHCHECK_COUNTRY> COVID_HEALTHCHECK_COUNTRY { get; set; }
        public virtual ICollection<COVID_HEALTHCHECK_SYMTOMS> COVID_HEALTHCHECK_SYMTOMS { get; set; }

        //additional
        public int[] COUNTRY { get; set; }
        public int[] SYMTOMS { get; set; }

        public long? PROVINCE_ID { get; set; }
        

    }
}
