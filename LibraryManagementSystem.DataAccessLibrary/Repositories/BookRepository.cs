using LibraryManagementSystem.ModelsLibrary;
using Microsoft.Data.SqlClient;

namespace LibraryManagementSystem.DataAccessLibrary.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly string _connectionString;

        public BookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public int AddBook(Book book)
        {
            int bookId = 0;

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("INSERT INTO Books(Title, Author, Genre, PublishedYear, IsDeleted) " +
                                                    "OUTPUT INSERTED.Id VALUES(@Title, @Author, @Genre, @PublishedYear, @IsDeleted)", connection))
                {
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@Genre", book.Genre);
                    command.Parameters.AddWithValue("@PublishedYear", book.PublishedYear);
                    command.Parameters.AddWithValue("@IsDeleted", 0);

                    connection.Open();
                    bookId = (int)command.ExecuteScalar();
                }
            }

            return bookId;
        }


        public IEnumerable<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT * FROM Books " +
                                                    "WHERE IsDeleted = @IsDeleted", connection))
                {
                    command.Parameters.AddWithValue("@IsDeleted", 0);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book book = DataReaderExtensions.GetBookData(reader);

                            books.Add(book);
                        }
                    }
                }
            }

            return books;
        }

        public Book GetBookById(int bookId)
        {
            Book book = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT * FROM Books " +
                                                    "WHERE Id = @BookId AND IsDeleted = @IsDeleted", connection))
                {
                    command.Parameters.AddWithValue("@BookId", bookId);
                    command.Parameters.AddWithValue("@IsDeleted", 0);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            book = DataReaderExtensions.GetBookData(reader);
                        }
                    }
                }
            }

            return book;
        }

        public IEnumerable<Book> GetBooksByTitle(string bookTitle)
        {
            List<Book> books = new List<Book>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT * FROM Books " +
                                                    "WHERE Title = @BookTitle AND IsDeleted = @IsDeleted", connection))
                {
                    command.Parameters.AddWithValue("@BookTitle", bookTitle);
                    command.Parameters.AddWithValue("@IsDeleted", 0);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var book = DataReaderExtensions.GetBookData(reader);
                            books.Add(book);
                        }
                    }
                }
            }

            return books;
        }


        public IEnumerable<Book> GetBooksByAuthor(string authorName)
        {
            List<Book> books = new List<Book>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT * FROM Books " +
                                                    "WHERE Author = @Author AND IsDeleted = @IsDeleted", connection))
                {
                    command.Parameters.AddWithValue("@Author", authorName);
                    command.Parameters.AddWithValue("@IsDeleted", 0);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book book = DataReaderExtensions.GetBookData(reader);

                            books.Add(book);
                        }
                    }
                }
            }

            return books;
        }

        public IEnumerable<Book> GetBooksByGenre(string genreName)
        {
            List<Book> books = new List<Book>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT * FROM Books " +
                                                    "WHERE Genre = @Genre AND IsDeleted = @IsDeleted", connection))
                {
                    command.Parameters.AddWithValue("@Genre", genreName);
                    command.Parameters.AddWithValue("@IsDeleted", 0);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book book = DataReaderExtensions.GetBookData(reader);

                            books.Add(book);
                        }
                    }
                }
            }

            return books;
        }

        public void UpdateBook(Book book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("UPDATE Books " +
                                                    "SET Title = @Title, Author = @Author, Genre = @Genre, PublishedYear = @PublishedYear " +
                                                    "WHERE Id = @BookId", connection))
                {
                    command.Parameters.AddWithValue("@BookId", book.Id);
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@Genre", book.Genre);
                    command.Parameters.AddWithValue("@PublishedYear", book.PublishedYear);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteBookById(int bookId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("UPDATE Books " +
                                                    "SET IsDeleted = @IsDeleted, DeletedOn = @DeletedOn " +
                                                    "WHERE Id = @BookId", connection))
                {
                    command.Parameters.AddWithValue("@BookId", bookId);
                    command.Parameters.AddWithValue("@IsDeleted", 1);
                    command.Parameters.AddWithValue("@DeletedOn", DateTime.UtcNow);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
