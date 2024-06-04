namespace Production.Core.DataTransferObject
{
    public class ProductionOperationsDto
    {
        public int OperationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Approval { get; set; }
        public string Type { get; set; }
    }
}
