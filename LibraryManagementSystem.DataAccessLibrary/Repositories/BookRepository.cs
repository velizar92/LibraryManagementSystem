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


        public void AddBook(Book book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("INSERT INTO Books(Title, Author, Genre, PublishedYear, IsDeleted) " +
                                                    "VALUES(@Title, @Author, @Genre, @PublishedYear, @IsDeleted)", connection))
                {
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@Genre", book.Genre);
                    command.Parameters.AddWithValue("@PublishedYear", book.PublishedYear);
                    command.Parameters.AddWithValue("@IsDeleted", 0);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
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
                            Book book = GetBookData(reader);

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
                            book = GetBookData(reader);
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
                            var book = GetBookData(reader);
                            books.Add(book);
                        }
                    }
                }
            }

            return books;
        }

        public Book GetBookFullInfoById(int bookId)
        {
            Book book = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT b.Id, b.Title, b.Author, b.Genre, b.PublishedYear, m.FirstName, m.LastName, " +
                                                    "m.Email, m.PhoneNumber, bb.BorrowDate, bb.ReturnDate " +
                                                    "FROM Books AS b " +
                                                    "JOIN BorrowedBooks AS bb ON bb.BookId = b.Id " +
                                                    "JOIN Members AS m ON bb.MemberId = m.Id " +
                                                    "WHERE b.Id = @BookId AND b.IsDeleted = @IsDeleted", connection))
                {
                    command.Parameters.AddWithValue("@BookId", bookId);
                    command.Parameters.AddWithValue("@IsDeleted", 0);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (book == null)
                            {
                                book = GetBookData(reader);
                                book.BorrowedBooks = new List<BorrowedBooks>();   
                            }

                            book.BorrowedBooks.Add(new BorrowedBooks
                            {
                                BorrowDate = reader["BorrowDate"] != DBNull.Value ? (DateTime?)reader["BorrowDate"] : null,
                                ReturnDate = reader["ReturnDate"] != DBNull.Value ? (DateTime?)reader["ReturnDate"] : null,
                                Member = new Member
                                {
                                    FirstName = reader["FirstName"] != DBNull.Value ? reader["FirstName"].ToString() : null,
                                    LastName = reader["LastName"] != DBNull.Value ? reader["LastName"].ToString() : null,
                                    Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null,
                                    PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? reader["PhoneNumber"].ToString() : null,
                                }
                            });

                        }
                    }
                }
            }

            return book;
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
                            Book book = GetBookData(reader);

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
                            Book book = GetBookData(reader);

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

        public IEnumerable<Book> GetBorrowedBooksByMemberId(int memberId)
        {
            List<Book> books = new List<Book>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT * FROM Books AS b " +
                                                    "JOIN BorrowedBooks AS bb ON bb.BookId = b.Id " +
                                                    "JOIN Members AS m ON bb.MemberId = m.Id " +
                                                    "WHERE m.Id = @MemberId AND IsDeleted = @IsDeleted AND bb.BorrowedDate IS NOT NULL", connection))
                {
                    command.Parameters.AddWithValue("@MemberId", memberId);
                    command.Parameters.AddWithValue("@IsDeleted", 0);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book book = GetBookData(reader);

                            books.Add(book);
                        }
                    }
                }
            }

            return books;
        }

        public IEnumerable<Book> GetAllBorrowedBooks()
        {
            List<Book> books = new List<Book>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT * FROM Books AS b " +
                                                    "JOIN BorrowedBooks AS bb ON bb.BookId = b.Id " +
                                                    "WHERE IsDeleted = @IsDeleted AND bb.BorrowedDate IS NOT NULL", connection))
                {
                    command.Parameters.AddWithValue("@IsDeleted", 0);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book book = GetBookData(reader);

                            books.Add(book);
                        }
                    }
                }
            }

            return books;
        }


        private Book GetBookData(SqlDataReader reader)
        {
            return new Book
            {
                Id = (int)reader["Id"],
                Title = reader["Title"] != DBNull.Value ? reader["Title"].ToString() : null,
                Author = reader["Author"] != DBNull.Value ? reader["Author"].ToString() : null,
                Genre = reader["Genre"] != DBNull.Value ? reader["Genre"].ToString() : null,
                PublishedYear = reader["PublishedYear"] != DBNull.Value ? reader["PublishedYear"].ToString() : null,
            };
        }
    }
}
