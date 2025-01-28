using LibraryManagementSystem.DataAccessLibrary.Repositories;

namespace LibraryManagementSystem.ServicesLibrary.Services
{
    public class BorrowedBookService : IBorrowedBookService
    {
        private IBorrowedBookRepository _borrowedBookRepository;

        public BorrowedBookService(IBorrowedBookRepository borrowedBookRepository)
        {
            _borrowedBookRepository = borrowedBookRepository;
        }

        public void BorrowBook(int bookId, int memberId, DateTime? borrowDate)
        {
            if (bookId < 0)
            {
                throw new ArgumentException($"The id is negative.", nameof(bookId));
            }

            if (memberId < 0)
            {
                throw new ArgumentException($"The id is negative.", nameof(memberId));
            }

            _borrowedBookRepository.BorrowBook(bookId, memberId, borrowDate);
        }

        public void ReturnBook(int borrowId, DateTime? returnDate)
        {
            if (borrowId < 0)
            {
                throw new ArgumentException($"The id is negative.", nameof(borrowId));
            }

            _borrowedBookRepository.ReturnBook(borrowId, returnDate);
        }
    }
}
