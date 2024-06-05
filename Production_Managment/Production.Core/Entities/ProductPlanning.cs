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

        public string ProductName { get; set; }

        public ProductPlanning()
        {
            // Initialize the collection to avoid null reference exception
            Products = new List<Product>();
        }
    }
}
