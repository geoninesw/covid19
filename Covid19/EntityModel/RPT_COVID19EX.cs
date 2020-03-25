using System;
using System.Collections.Generic;

namespace Covid19.EntityModel
{
    public partial class RPT_COVID19EX
    {
        public RPT_COVID19EX()
        {
            RPT_COVID19EX_COUNTRY = new HashSet<RPT_COVID19EX_COUNTRY>();
            RPT_COVID19EX_SYMTOMS = new HashSet<RPT_COVID19EX_SYMTOMS>();
            RPT_COVID19EX_SYMTOMS_OTHER = new HashSet<RPT_COVID19EX_SYMTOMS_OTHER>();
        }

        public int ID { get; set; }
        public string PERSON_ID { get; set; }
        public int? REPORTER { get; set; }
        public bool? TRAVEL_FLAG { get; set; }
        public DateTime? DEPARTURE_DT { get; set; }
        public string DEPARTURE_FLIGHT { get; set; }
        public DateTime? ARRIVAL_DT { get; set; }
        public string ARRIVAL_FLIGHT { get; set; }
        public string HAS_FLU { get; set; }
        public string HAS_FLU_OTHER { get; set; }
        public string COMPANION_NAME1 { get; set; }
        public string COMPANION_RELATION1 { get; set; }
        public string COMPANION_NAME2 { get; set; }
        public string COMPANION_RELATION2 { get; set; }
        public string COMPANION_NAME3 { get; set; }
        public string COMPANION_RELATION3 { get; set; }
        public bool? TRAVEL_TOGETHER { get; set; }
        public decimal? TEMPERATURE { get; set; }
        public decimal? TEMPERATURE_OTHER { get; set; }
        public bool? CLOSE_PATIENT_FLAG { get; set; }
        public string CLOSE_PATIENT_DETAIL { get; set; }
        public DateTime? CREATED_DT { get; set; }

        public virtual ICollection<RPT_COVID19EX_COUNTRY> RPT_COVID19EX_COUNTRY { get; set; }
        public virtual ICollection<RPT_COVID19EX_SYMTOMS> RPT_COVID19EX_SYMTOMS { get; set; }
        public virtual ICollection<RPT_COVID19EX_SYMTOMS_OTHER> RPT_COVID19EX_SYMTOMS_OTHER { get; set; }
    }
}
