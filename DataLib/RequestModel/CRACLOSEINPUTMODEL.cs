using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.RequestModel
{

    public class CRACLOSEINPUTMODEL
    {
        public string requestId { get; set; }
        public string id { get; set; }
        public string serviceNumber { get; set; }
        public string resellerCode { get; set; } = "41";
    }

}
