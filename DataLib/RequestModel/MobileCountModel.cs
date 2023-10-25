namespace DataLib
{
    public class MobileCountModel
    {
        public string identificationNo { get; set; }
        public int identificationType { get; set; }
        public string requestId { get; set; } = CRASEQUENCE.SeqIDGenerator();
    }
}