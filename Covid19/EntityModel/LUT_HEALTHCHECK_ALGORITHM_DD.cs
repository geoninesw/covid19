using System;
using System.Collections.Generic;

namespace Covid19.EntityModel
{
    public partial class LUT_HEALTHCHECK_ALGORITHM_DD
    {
        public int ID { get; set; }
        public string ATTRIBUTE { get; set; }
        public string DATA_TYPE { get; set; }
        public string DESCRIPTION { get; set; }
        public string DATA_SCOPE { get; set; }
        public string DATA_SIZE { get; set; }
        public byte MANDATORY_FIELD { get; set; }
        public string CHARACTERISTIC { get; set; }
        public string DATA_FORMAT { get; set; }
    }
}
