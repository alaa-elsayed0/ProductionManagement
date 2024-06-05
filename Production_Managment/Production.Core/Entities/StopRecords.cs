namespace Production.Core.Entities
{
    public class StopRecords : BaseEntity<int>
    {
        public string StopReasons { get; set; }
        public int DownTimeDuration { get; set; }
        public string AffectedOperations { get; set; }

        public ICollection<ProductPlanning> ProductPlannings { get; set; }
        public ProductPlanning? ProductPlanning { get; set; }

        public string ProductName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
