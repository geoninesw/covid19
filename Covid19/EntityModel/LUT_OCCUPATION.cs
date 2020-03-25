using System;
using System.Collections.Generic;

namespace Covid19.EntityModel
{
    public partial class LUT_OCCUPATION
    {
        public LUT_OCCUPATION()
        {
            COVID_HEALTHCHECK = new HashSet<COVID_HEALTHCHECK>();
        }

        public int ID { get; set; }
        public string SHORT_DESCR { get; set; }
        public string DESCR { get; set; }

        public virtual ICollection<COVID_HEALTHCHECK> COVID_HEALTHCHECK { get; set; }
    }
}
