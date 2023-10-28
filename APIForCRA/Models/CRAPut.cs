using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIForCRA
{
    public class CRAPut
    {
        public int identificationType { get; set; }
        public string identificationNo { get; set; }
        public string certificateNo { get; set; }
        public string birthDate { get; set; }
        public string name { get; set; }
        public string family { get; set; }
        public string fatherName { get; set; }
        public int gender { get; set; }
        public string birthPlace { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public int person { get; set; } = 1;
        public int iranian { get; set; } = 1;
        public int isUnderLegalAge { get; set; }
        public PAddress address { get; set; }
        public PService service { get; set; }
    }
    public class PAddress
    {
        public string provinceName { get; set; }
        public string townshipName { get; set; }
        public string address { get; set; }
        public string street2 { get; set; }
        public string houseNumber { get; set; }
        public string postalCode { get; set; }
        public string tel { get; set; }
    }

    public class PService
    {
        public int? type { get; set; }
        public string mobileNumber { get; set; }
        public int? mobileType { get; set; }
        public int? dataSim { get; set; }
        public string serial { get; set; }
        public int? sms { get; set; }
        public int? gprs { get; set; }
        public int? mms { get; set; }
        public int? wap { get; set; }
        public int? threeG { get; set; }
        public int? fourG { get; set; }
        public int? videoCall { get; set; }
        public int? ipStatic { get; set; }
        public string province { get; set; }
        public string networkName { get; set; }
        public string apn { get; set; }
        public int? privateNumber { get; set; }
        public int? privateNumberDetection { get; set; }
    }
}
