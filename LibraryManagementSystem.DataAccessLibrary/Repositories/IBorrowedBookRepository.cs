using LibraryManagementSystem.ModelsLibrary;

namespace LibraryManagementSystem.DataAccessLibrary.Repositories
{
    public interface IBorrowedBookRepository
    {
        void BorrowBook(int bookId, int memberId, DateTime borrowDate);
        void ReturnBook(int borrowId, DateTime returnDate);
        bool IsBookBorrowed(int bookId);
        int GetBookIdByBorrowId(int borrowId);
        Book GetBookFullInfoById(int bookId);
        IEnumerable<Book> GetBorrowedBooksByMemberId(int memberId);
        IEnumerable<Book> GetAllBorrowedBooks();
    }
}
