﻿using LibraryManagementSystem.DataAccessLibrary.Repositories;

namespace LibraryManagementSystem.ServicesLibrary.Services
{
    public class BorrowedBookService : IBorrowedBookService
    {
        private IBorrowedBookRepository _borrowedBookRepository;
        private IBookRepository _bookRepository;
        private IMemberRepository _memberRepository;

        public BorrowedBookService(IBorrowedBookRepository borrowedBookRepository,
            IBookRepository bookRepository, IMemberRepository memberRepository)
        {
            _borrowedBookRepository = borrowedBookRepository;
            _bookRepository = bookRepository;
            _memberRepository = memberRepository;
        }

        public void BorrowBook(int bookId, int memberId, DateTime borrowDate)
        {
            if (bookId < 0)
            {
                throw new ArgumentException($"The book id is negative.", nameof(bookId));
            }

            if (memberId < 0)
            {
                throw new ArgumentException($"The member id is negative.", nameof(memberId));
            }

            if(_bookRepository.GetBookById(bookId) == null)
            {
                throw new InvalidOperationException("The book does not exist!");
            }

            if (_memberRepository.GetMemberById(memberId) == null)
            {
                throw new InvalidOperationException("The member does not exist!");
            }

            if (borrowDate > DateTime.Now)
            {
                throw new ArgumentException("The borrow date cannot be in the future.", nameof(borrowDate));
            }


            bool isBookBorrowed = _borrowedBookRepository.IsBookBorrowed(bookId);
            
            if (isBookBorrowed == true)
            {
                throw new InvalidOperationException("The book is already borrowed.");
            }
            
            _borrowedBookRepository.BorrowBook(bookId, memberId, borrowDate);
        }

        public void ReturnBook(int borrowId, DateTime returnDate)
        {
            if (borrowId < 0)
            {
                throw new ArgumentException($"The id is negative.", nameof(borrowId));
            }

            _borrowedBookRepository.ReturnBook(borrowId, returnDate);
        }
    }
}
