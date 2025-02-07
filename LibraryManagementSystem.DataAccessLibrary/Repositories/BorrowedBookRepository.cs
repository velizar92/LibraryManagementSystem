using LibraryManagementSystem.ModelsLibrary;
using Microsoft.Data.SqlClient;

namespace LibraryManagementSystem.DataAccessLibrary.Repositories
{
    public class BorrowedBookRepository : IBorrowedBookRepository
    {
        private readonly string _connectionString;

        public BorrowedBookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void BorrowBook(int bookId, int memberId, DateTime borrowDate)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("INSERT INTO BorrowedBooks(BookId, MemberId, BorrowDate, IsDeleted, ReturnDate) " +
                                                    "VALUES(@BookId, @MemberId, @BorrowDate, @IsDeleted, @ReturnDate)", connection))
                {
                    command.Parameters.AddWithValue("@BookId", bookId);
                    command.Parameters.AddWithValue("@MemberId", memberId);
                    command.Parameters.AddWithValue("@BorrowDate", borrowDate);
                    command.Parameters.AddWithValue("@IsDeleted", 0);
                    command.Parameters.AddWithValue("@ReturnDate", null);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public void ReturnBook(int borrowId, DateTime returnDate)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("UPDATE BorrowedBooks " +
                                                    "SET ReturnDate = @ReturnDate, BorrowedDate = @BorrowedDate " +
                                                    "WHERE Id = @BorrowId AND IsDeleted = @IsDeleted", connection))
                {
                    command.Parameters.AddWithValue("@BorrowId", borrowId);
                    command.Parameters.AddWithValue("@BorrowedDate", null);
                    command.Parameters.AddWithValue("@ReturnDate", returnDate);
                    command.Parameters.AddWithValue("@IsDeleted", 0);
                  
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool IsBookBorrowed(int bookId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT COUNT(*) FROM BorrowedBooks " +
                                                    "WHERE BookId = @BookId AND ReturnDate IS NULL " +
                                                    "AND IsDeleted = @IsDeleted", connection))
                {
                    command.Parameters.AddWithValue("@BookId", bookId);
                    command.Parameters.AddWithValue("@IsDeleted", 0);
                  
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public int GetBookIdByBorrowId(int borrowId)
        {
            int bookId = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT BookId FROM BorrowedBooks " +
                                                    "WHERE Id = @BorrowId AND IsDeleted = @IsDeleted", connection))
                {
                    command.Parameters.AddWithValue("@BorrowId", borrowId);
                    command.Parameters.AddWithValue("@IsDeleted", 0);

                    connection.Open();
                    bookId = (int)command.ExecuteScalar();        
                }
            }

            return bookId;
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
                                book = DataReaderExtensions.GetBookData(reader);
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
                            Book book = DataReaderExtensions.GetBookData(reader);

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
                            Book book = DataReaderExtensions.GetBookData(reader);

                            books.Add(book);
                        }
                    }
                }
            }

            return books;
        }
    }
}
