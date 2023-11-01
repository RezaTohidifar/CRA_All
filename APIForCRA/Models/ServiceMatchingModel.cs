using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace APIForCRA
{
    public class ServiceMatchingM
    {
        public string serviceNum { get; set; }
        public string identificationNom { get; set; }
        [DefaultValue(1)]
        public int? idType { get; set; }
    }
}
