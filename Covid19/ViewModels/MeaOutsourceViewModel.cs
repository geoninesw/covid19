using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.ViewModels
{
    public class MeaOutsourceViewModel
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
    }
}
