using System;
using System.Collections.Generic;

namespace Covid19.EntityModel
{
    public partial class COVID_HEALTHCHECK_SYMTOMS
    {
        public int ID { get; set; }
        public int REPORTER_ID { get; set; }
        public int? SYMTOMS_ID { get; set; }
    }
}
