namespace LMS.DTOs.Borrower
{
    public class BorrowerCreateDto
    {
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime BorrowDate { get; set; }
    }
}
