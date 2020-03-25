using System;
using System.Collections.Generic;

namespace Covid19.EntityModel
{
    public partial class AUTH_USER
    {
        public int ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string SALT { get; set; }
        public bool IS_ACTIVE { get; set; }
    }
}
