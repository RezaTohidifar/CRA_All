using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib
{
    public class URLDictionary
    {
        public static Dictionary<string, string> AllURL { get; set; }
        public static void URLMETHOD()
        {
            AllURL = new Dictionary<string, string>();
            AllURL.Add("Query", "http://172.22.7.16:8280/Shahkar/1.4/provider-enquiry");
            AllURL.Add("Put", "http://172.22.7.16:8280/Shahkar/1.4/put");
            AllURL.Add("Close", "http://172.22.7.16:8280/Shahkar/1.4/delete");
            AllURL.Add("MobileCount", "http://172.22.7.16:8280/Shahkar/1.4/mobileCount");
            AllURL.Add("Matching", "http://172.22.7.16:8280/Shahkar/1.4/serviceID-matching");

        }

    }

}
