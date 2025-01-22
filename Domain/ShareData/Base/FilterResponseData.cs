namespace Domain.ShareData.Base
{
    public class FilterResponseData
    {
        public string StartingAfter { get; set; }
        public string EndingBefore { get; set; }
        public long? Limit { get; set; }
    }
}
