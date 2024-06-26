﻿using System.Runtime.Serialization;

namespace Production.Core.Entities
{
    public class Tracking : BaseEntity<int>
    {
        public DateTime Date { get; set; }
        public int QuantityProduced { get; set; }
        public string Comments { get; set; }

        public ICollection<ProductPlanning> ProductPlannings { get; set; }
        public ProductPlanning? ProductPlanning { get; set; }
        public string ProductName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
