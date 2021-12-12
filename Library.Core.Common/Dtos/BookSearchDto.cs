namespace Library.Core.Common.Dtos
{
    public class BookSearchDto : BaseSearch
    {
        public string? Title { get; set; }
        public int? Published { get; set; }
    }
}
