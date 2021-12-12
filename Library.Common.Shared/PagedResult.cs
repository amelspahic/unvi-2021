namespace Library.Common.Shared
{
    public class PagedResult<T>
    {
        public long? Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
