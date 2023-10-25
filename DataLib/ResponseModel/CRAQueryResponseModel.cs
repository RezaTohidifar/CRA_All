using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.ResponseModel
{
    public class CRAQueryResponseModel
    {

            public string result { get; set; }
            public string requestId { get; set; }
            public int response { get; set; }
            public string classifier { get; set; }
            public string comment { get; set; }
            public string providerName { get; set; }
            public string servicenumber { get; set; }
    }
}
