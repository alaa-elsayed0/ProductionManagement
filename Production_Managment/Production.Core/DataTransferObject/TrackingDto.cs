namespace Production.Core.DataTransferObject
{
    public class TrackingDto
    {
        public int TrackingId { get; set; }
        public DateTime Date { get; set; }
        public int QuantityProduced { get; set; }
        public string Comments { get; set; }
    }
}
