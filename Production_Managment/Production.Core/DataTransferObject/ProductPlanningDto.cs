namespace Production.Core.DataTransferObject
{
    public class ProductPlanningDto
    {
        public int PlanningId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Approval { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }

        public string ProductName { get; set; }

    }
}
