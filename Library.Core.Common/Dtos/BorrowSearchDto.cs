namespace Library.Core.Common.Dtos
{
    public class BorrowSearchDto : BaseSearch
    {
        public string? StudentName { get; set; }
        public string? BookName { get; set; }
        public DateOnly? TakenDate { get; set; }
        public DateOnly? ReturnDate { get; set; }
    }
}
