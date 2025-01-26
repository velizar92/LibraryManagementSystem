using LibraryManagementSystem.ModelsLibrary;

namespace LibraryManagementSystem.DataAccessLibrary.Repositories
{
    public class BookRepository : IBookRepository
    {
        public void AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBookById(int bookId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Book GetBookById(int bookId)
        {
            throw new NotImplementedException();
        }

        public Book GetBookByTitle(string bookTitle)
        {
            throw new NotImplementedException();
        }

        public Book GetBookFullInfoById(int bookId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetBooksByAuthor(string authorName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetBooksByGenre(string genreName)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
