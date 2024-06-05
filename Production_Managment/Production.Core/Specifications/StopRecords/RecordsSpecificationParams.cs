namespace Production.Core.Specifications.StopRecords
{
    public class RecordsSpecificationParams
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
