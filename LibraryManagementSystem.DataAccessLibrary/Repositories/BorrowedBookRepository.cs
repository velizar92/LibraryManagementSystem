using LibraryManagementSystem.ModelsLibrary;

namespace LibraryManagementSystem.DataAccessLibrary.Repositories
{
    public class BorrowedBookRepository : IBorrowedBookRepository
    {
        public void BorrowBook(int bookId, int memberId, DateTime borrowDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BorrowedBooks> GetAllBorrowedBooks()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BorrowedBooks> GetBorrowedBooksByBook(int bookId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BorrowedBooks> GetBorrowedBooksByMember(int memberId)
        {
            throw new NotImplementedException();
        }

        public void ReturnBook(int borrowId, DateTime returnDate)
        {
            throw new NotImplementedException();
        }
    }
}
