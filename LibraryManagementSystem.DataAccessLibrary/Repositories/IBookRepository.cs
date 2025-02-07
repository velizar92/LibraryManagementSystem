using LibraryManagementSystem.ModelsLibrary;

namespace LibraryManagementSystem.DataAccessLibrary.Repositories
{
    public interface IBookRepository
    {
        int AddBook(Book book);
        Book GetBookById(int bookId);
        IEnumerable<Book> GetBooksByTitle(string bookTitle);
        IEnumerable<Book> GetBooksByAuthor(string authorName);
        IEnumerable<Book> GetBooksByGenre(string genreName);
        IEnumerable<Book> GetAllBooks();
        void UpdateBook(Book book);
        void DeleteBookById(int bookId);
    }
}
