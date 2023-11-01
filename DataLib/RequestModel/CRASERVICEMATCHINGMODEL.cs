namespace DataLib
{
    public class CARSERVICEMATCHINGMODEL
    {
        public int serviceType { get; set; } = 2;
        public string serviceNumber { get; set; }
        public string requestId { get; set; } = CRASEQUENCE.SeqIDGenerator();
        public string identificationNo { get; set; }
        public int? identificationType { get; set; }
    }
}