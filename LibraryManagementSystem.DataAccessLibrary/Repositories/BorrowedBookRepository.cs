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
                using (var command = new SqlCommand("INSERT INTO BorrowedBooks(BookId, MemberId, BorrowDate) " +
                                                    "VALUES(@BookId, @MemberId, @BorrowDate)", connection))
                {
                    command.Parameters.AddWithValue("@BookId", bookId);
                    command.Parameters.AddWithValue("@MemberId", memberId);
                    command.Parameters.AddWithValue("@BorrowDate", borrowDate);

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
                                                    "SET ReturnDate = @ReturnDate, BorrowedDate = NULL " +
                                                    "WHERE Id = @BorrowId", connection))
                {
                    command.Parameters.AddWithValue("@BorrowId", borrowId);
                    command.Parameters.AddWithValue("@ReturnDate", returnDate);
                  
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
