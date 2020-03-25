using Covid19.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.ViewModels
{
    public class RptCovid19ExViewModel
    {
        public int? ID { get; set; }
        public string PERSON_ID { get; set; }
        public Nullable<int> REPORTER { get; set; }
        public Nullable<System.DateTime> DEPARTURE_DT { get; set; }
        public string DEPARTURE_FLIGHT { get; set; }
        public Nullable<System.DateTime> ARRIVAL_DT { get; set; }
        public string ARRIVAL_FLIGHT { get; set; }
        public string HAS_FLU { get; set; }
        public string HAS_FLU_OTHER { get; set; }
        public string COMPANION_NAME1 { get; set; }
        public string COMPANION_RELATION1 { get; set; }
        public string COMPANION_NAME2 { get; set; }
        public string COMPANION_RELATION2 { get; set; }
        public string COMPANION_NAME3 { get; set; }
        public string COMPANION_RELATION3 { get; set; }
        public Nullable<bool> TRAVEL_TOGETHER { get; set; }
        public Nullable<bool> TRAVEL_FLAG { get; set; }
        public Nullable<decimal> TEMPERATURE { get; set; }
        public Nullable<decimal> TEMPERATURE_OTHER { get; set; }
        public bool? CLOSE_PATIENT_FLAG { get; set; }
        public string CLOSE_PATIENT_DETAIL { get; set; }
        public Nullable<System.DateTime> CREATED_DT { get; set; }

        public virtual ICollection<RPT_COVID19EX_SYMTOMS> RPT_COVID19EX_SYMTOMS { get; set; }
        public virtual ICollection<RPT_COVID19EX_SYMTOMS_OTHER> RPT_COVID19EX_SYMTOMS_OTHER { get; set; }
        public virtual ICollection<RPT_COVID19EX_COUNTRY> RPT_COVID19EX_COUNTRY { get; set; }

        //additional
        public int[] COUNTRY { get; set; }
        public int[] COUNTRY2 { get; set; }
        public int[] SYMTOMS { get; set; }
        public int[] SYMTOMS_OTHER { get; set; }
        public string SYMTOMS_OTHER_TEXT { get; set; }
        public string SYMTOMS_OTHER_TEXT_OTHER { get; set; }
        public string SYMTOMS2_OTHER_TEXT { get; set; }
        public int[] SYMTOMS2 { get; set; }
        public int? COUNTRY_ID { get; set; }
        public int? COUNTRY_ID2 { get; set; }
        public int[] REPORTERS { get; set; }
        public string FULLNAME { get; set; }
        public DateTime? ARRIVAL_DT2 { get; set; }
        public string HAS_FLU2 { get; set; }
        public DateTime? DEPARTURE_DT2 { get; set; }
        public string DEPARTURE_FLIGHT2 { get; set; }
        public string ARRIVAL_FLIGHT2 { get; set; }
        public string ORGANIZATION { get; set; }
        public string ArriveDate { get; set; }
        public string ReportDate { get; set; }
        public string AllSymtoms { get; set; }
        public string DEPARTURE_DT_TXT { get; set; }
        public string DEPARTURE_DT_TXT2 { get; set; }
        public string ARRIVAL_DT_TXT { get; set; }
        public string ARRIVAL_DT_TXT2 { get; set; }
        public string COUNTRY_TXT { get; set; }
        public string COUNTRY_TXT2 { get; set; }
        public List<RptCovid19ExViewModel> HISTORY { get; set; }
        public List<RptCovid19ExViewModel> HISTORY2 { get; set; }
        public List<RptCovid19ExViewModel> HISTORY_NO_TRAVEL { get; set; }
        public string REPORT_DT_TXT { get; set; }
        public string SYMTOMS_TXT { get; set; }
        public string CLOSE_PATIENT_FLAG_TXT { get; set; }

        public string TravelFlag { get; set; }  // 1 = เดินทาง ,0 = ไม่เดินทาง
        public string JOBDESC { get; set; }
    }
}
