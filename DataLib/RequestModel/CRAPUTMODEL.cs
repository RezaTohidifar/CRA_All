
namespace DataLib
{

    public class CRAPUTMODEL
    {
        public string requestId { get; set; } = CRASEQUENCE.SeqIDGenerator();
        public string resellerCode { get; set; } = "41";
        public int identificationType { get; set; }
        public string identificationNo { get; set; }
        public string certificateNo { get; set; }
        public string birthDate { get; set; }
        public string name { get; set; }
        public string family { get; set; }
        public string fatherName { get; set; }
        public int gender { get; set; }
        public string birthPlace { get; set; }
        public string  mobile { get; set; }
        public string  email { get; set; }
        public int  person { get; set; } = 1;
        public int  iranian { get; set; } = 1;
        public int  isUnderLegalAge { get; set; } = 0;
        public Address  address { get; set; }
        public Service  service { get; set; }
    }

    public class Address
    {
        public string provinceName { get; set; }
        public string  townshipName { get; set; }
        public string  address { get; set; }
        public string  street2 { get; set; }
        public string  houseNumber { get; set; }
        public string  postalCode { get; set; }
        public string  tel { get; set; }
    }

    public class Service
    {
        public int? type { get; set; } = 2;
        public string mobileNumber { get; set; }
        public int? mobileType { get; set; }
        public int? dataSim { get; set; } = 0;
        public string serial { get; set; }
        public int? sms { get; set; } = 1;
        public int? gprs { get; set; } = 1;
        public int? mms { get; set; } = 0;
        public int? wap { get; set; } = 0;
        public int? threeG { get; set; } = 1;
        public int? fourG { get; set; } = 1;
        public int? videoCall { get; set; } = 0;
        public int? ipStatic { get; set; } = 0;
        public string province { get; set; } = "021";
        public string networkName { get; set; } = "RTL";
        public string apn { get; set; } = "RTL";
        public int? privateNumber { get; set; }
        public int? privateNumberDetection { get; set; }
    }
}