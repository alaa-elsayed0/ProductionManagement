namespace Production.Core.Specifications
{
    public class ProductSpecificationParameters
    {
        public string Name { get; set; }

        private string? _search;

        public string? Search
        {
            get => _search;
            set => _search = value?.Trim().ToLower();
        }
    }
}
