using LibraryManagementSystem.ModelsLibrary;

namespace LibraryManagementSystem.DataAccessLibrary.Repositories
{
    public interface IBorrowedBookRepository
    {
        void BorrowBook(int bookId, int memberId, DateTime borrowDate);
        void ReturnBook(int borrowId, DateTime returnDate);
        IEnumerable<BorrowedBooks> GetBorrowedBooksByMember(int memberId);
        IEnumerable<BorrowedBooks> GetBorrowedBooksByBook(int bookId);
        IEnumerable<BorrowedBooks> GetAllBorrowedBooks();
    }
}
