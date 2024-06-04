namespace Production.Core.Entities
{
    public class ProductPlanning : BaseEntity<int>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Approval { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }

        public ICollection<Product> Products { get; set; }

        public Product? Product { get; set; }


    }
}
