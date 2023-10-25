using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib
{
    public class CRASEQUENCE
    {
        public static string SeqIDGenerator()
        {
            Random rnd = new();
            string seqid = $"0130" + $"{DateTime.Now.ToString("yyyyMMddHHmmssffff") + $"{rnd.Next(11, 99)}"}";
            return seqid;
        }
    }
}
