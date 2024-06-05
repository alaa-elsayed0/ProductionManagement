namespace Production.Core.Specifications.Planning
{
    public class PlanSpecParams
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
