using System;
using System.Collections.Generic;

namespace Covid19.EntityModel
{
    public partial class LUT_HEALTHCHECK_ALGORITHM
    {
        public int ID { get; set; }
        public byte? FEVER { get; set; }
        public byte? ONE_URI_SYMP { get; set; }
        public byte? TRAVEL_RISK_COUNTRY { get; set; }
        public byte? COVID19_CONTACT { get; set; }
        public byte? CLOSE_RISK_COUNTRY { get; set; }
        public byte? INT_CONTACT { get; set; }
        public byte? MED_PROF { get; set; }
        public byte? CLOSE_CON { get; set; }
        public byte? RISK_LEVEL { get; set; }
        public string GEN_ACTION { get; set; }
        public string SPEC_ACTION { get; set; }
    }
}
