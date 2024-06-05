namespace Production.Core.Entities
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }

        public ICollection<StopRecords> StopRecords { get; set; }
        public ICollection<Tracking> Trackings { get; set; }
    }
}
