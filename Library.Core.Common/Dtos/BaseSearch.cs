using Library.Common.Shared;

namespace Library.Core.Common.Dtos
{
    public abstract class BaseSearch
    {
        protected BaseSearch()
        {
            Includes = new List<string>();
        }

        public int? PageSize { get; set; }
        public int? Page { get; set; }
        public bool? RetrieveAll { get; set; }
        public bool? IncludeCount { get; set; }
        public string? SortBy { get; set; }
        public SortOrder? SortOrder { get; set; }
        public List<string> Includes { get; set; }
    }
}
