namespace Production.Core.DataTransferObject
{
    public class StopRecordsDto
    {
        public int StopRecordsId { get; set; }
        public string StopReasons { get; set; }
        public int DownTimeDuration { get; set; }
        public string AffectedOperations { get; set; }
    }
}
