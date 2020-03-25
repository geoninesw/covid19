using System;
using System.Collections.Generic;

namespace Covid19.EntityModel
{
    public partial class LUT_PROVINCE
    {
        public LUT_PROVINCE()
        {
            COVID_HEALTHCHECK = new HashSet<COVID_HEALTHCHECK>();
        }

        public long ID { get; set; }
        public string PROV_CODE { get; set; }
        public string AMP_CODE { get; set; }
        public string TAM_CODE { get; set; }
        public string PROV_NAMT { get; set; }
        public string PROV_NAME { get; set; }
        public string AMP_NAMT { get; set; }
        public string AMP_NAME { get; set; }
        public string TAM_NAMT { get; set; }
        public string TAM_NAME { get; set; }
        public string POSTCODE { get; set; }

        public virtual ICollection<COVID_HEALTHCHECK> COVID_HEALTHCHECK { get; set; }
    }
}
