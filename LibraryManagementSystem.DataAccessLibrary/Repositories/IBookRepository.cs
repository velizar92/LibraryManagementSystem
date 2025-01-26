using LibraryManagementSystem.ModelsLibrary;

namespace LibraryManagementSystem.DataAccessLibrary.Repositories
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        Book GetBookById(int bookId);
        Book GetBookByTitle(string bookTitle);
        Book GetBookFullInfoById(int bookId);
        IEnumerable<Book> GetBooksByAuthor(string authorName);
        IEnumerable<Book> GetBooksByGenre(string genreName);
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetBorrowedBooksByMemberId(int memberId);
        IEnumerable<Book> GetAllBorrowedBooks();
        void UpdateBook(Book book);
        void DeleteBookById(int bookId);
    }
}
