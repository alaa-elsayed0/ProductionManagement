namespace Production.Core.DataTransferObject
{
    public class StopRecordsDto
    {
        public int Id { get; set; }
        public string StopReasons { get; set; }
        public int DownTimeDuration { get; set; }
        public string AffectedOperations { get; set; }
        public string ProductName { get; set; }

    } 
}
