namespace LibraryManagementSystem.ServicesLibrary.Services
{
    public interface IBorrowedBookService
    {
        void BorrowBook(int bookId, int memberId, DateTime? borrowDate);
        void ReturnBook(int borrowId, DateTime? returnDate);
    }
}
