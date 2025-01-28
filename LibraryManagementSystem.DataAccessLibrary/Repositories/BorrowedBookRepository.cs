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
    }
}
