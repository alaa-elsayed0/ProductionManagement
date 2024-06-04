namespace Production.Core.Entities
{
    public class ProductionOperation : BaseEntity<int>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Approval { get; set; }
        public string Type { get; set; }

        public ICollection<ProductPlanning> ProductPlannings { get; set; }
        public ProductPlanning? ProductPlanning { get; set; }


    }
}
