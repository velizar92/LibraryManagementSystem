namespace LibraryManagementSystem.ModelsLibrary
{
    public class BorrowedBooks : BaseDeletableEntity
    {
        public int Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
