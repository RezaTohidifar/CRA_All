using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib
{
    public class DBLOG
    {
        public string seqId { get; set; } = CRASEQUENCE.SeqIDGenerator();
        public string request { get; set; }
        public string response { get; set; }
        public int? elapsedTime { get; set; }
        public string requestTime { get; set; }
        public string responseTime { get; set; }
        public string target { get; set; }
        public string exceptions { get; set; }
    }
}
