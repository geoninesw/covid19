using System;
using System.Collections.Generic;

namespace Covid19.EntityModel
{
    public partial class LUT_COVID_SYMTOM
    {
        public int ID { get; set; }
        public string SYMTOM { get; set; }
        public int? ORDER_DISPLAY { get; set; }
    }
}
