using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.ViewModels
{
    public class CovidHealthCheckAlgorithmViewModel
    {
        public int fever { get; set; }
        public int one_uri_symp { get; set; }
        public int travel_risk_country { get; set; }
        public int covid19_contact { get; set; }
        public int close_risk_country { get; set; }
        public int int_contact { get; set; }
        public int med_prof { get; set; }
        public int close_con { get; set; }
        public string gen_action { get; set; }
        public string spec_action { get; set; }
        public int risk_level { get; set; }

        // Additional
        public bool is_travel_in_14_days { get; set; }
    }
}
