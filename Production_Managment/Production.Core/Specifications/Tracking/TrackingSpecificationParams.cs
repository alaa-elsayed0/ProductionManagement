namespace Production.Core.Specifications.Tracking
{
    public class TrackingSpecificationParams
    {
        public string ProductName { get; set; }

        private string? _search;

        public string? Search
        {
            get => _search;
            set => _search = value?.Trim().ToLower();
        }
    }
}
