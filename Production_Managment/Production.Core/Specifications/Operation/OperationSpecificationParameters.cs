namespace Production.Core.Specifications.Operation
{
    public class OperationSpecificationParameters 
    {
        public string Type { get; set; }

        private string? _search;

        public string? Search
        {
            get => _search;
            set => _search = value?.Trim().ToLower();
        }
    }
}
