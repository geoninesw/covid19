using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.ViewModels
{
    public class EmployeeViewModel
    {
        public string PERSON_ID { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string ORGDESC { get; set; }
        public string JOBDESC { get; set; }
        public string EMAIL { get; set; }
        public string TEL { get; set; }
        public Nullable<System.DateTime> STARTDATE { get; set; }
        public Nullable<System.DateTime> ENDDATE { get; set; }
        public Nullable<System.DateTime> CREATED_DT { get; set; }
        public string FULLNAME { get; set; }

        public DateTime? BIRTHDATE { get; set; }
        public int? NATIONALITY { get; set; }
        public string HOUSE_NO { get; set; }
        public string MOO { get; set; }
        public string JOURNEY_DESCR { get; set; }
        public DateTime? DEPARTURE_DT { get; set; }
        public DateTime? ARRIVAL_DT { get; set; }
        public DateTime? REPORT_DT { get; set; }
        public string RESPONSIBLE_BY { get; set; }
        public string PROV_CODE { get; set; }
        public string AMP_CODE { get; set; }
        public string TAM_CODE { get; set; }
    }
}
