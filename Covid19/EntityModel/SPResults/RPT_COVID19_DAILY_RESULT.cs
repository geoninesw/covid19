using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.EntityModel.SPResults
{
    public class RPT_COVID19_DAILY_RESULT
    {
        public Nullable<int> REPORT_NUM { get; set; }
        public Nullable<int> ID { get; set; }
        public string LABEL { get; set; }
        public Nullable<int> AMOUNT { get; set; }
    }
}
