using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.RequestModel
{
    public class CRAQueryInputModel
    {
        public string serviceType { get; set; } = "2";
        public string serviceNumber { get; set; }
        public string requestId { get; set; }

    }
}
