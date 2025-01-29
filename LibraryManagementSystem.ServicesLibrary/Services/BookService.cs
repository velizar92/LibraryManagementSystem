﻿using LibraryManagementSystem.DataAccessLibrary.Repositories;
using LibraryManagementSystem.ModelsLibrary;

namespace LibraryManagementSystem.ServicesLibrary.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "The book parameter cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(book.Title)
                || string.IsNullOrWhiteSpace(book.Author))
            {
                throw new ArgumentException("Title and Author must be provided!");
            }

            _bookRepository.AddBook(book);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public IEnumerable<Book> GetAllBorrowedBooks()
        {
            return _bookRepository.GetAllBorrowedBooks();
        }

        public Book GetBookById(int bookId)
        {
            if (bookId < 0)
            {
                throw new ArgumentException("Book Id cannot be negative!", nameof(bookId));
            }

            if(_bookRepository.GetBookById(bookId) == null)
            {
                throw new InvalidOperationException($"Book with this id {bookId} does not exist!");
            }

            return _bookRepository.GetBookById(bookId);
        }

        public IEnumerable<Book> GetBooksByTitle(string bookTitle)
        {
            if (string.IsNullOrWhiteSpace(bookTitle))
            {
                throw new ArgumentException("Title cannot be empty!", nameof(bookTitle));
            }

            return _bookRepository.GetBooksByTitle(bookTitle);
        }

        public Book GetBookFullInfoById(int bookId)
        {
            if (bookId < 0)
            {
                throw new ArgumentException("Book Id cannot be negative!", nameof(bookId));
            }

            if (_bookRepository.GetBookFullInfoById(bookId) == null)
            {
                throw new InvalidOperationException($"Book with this id {bookId} does not exist!");
            }

            return _bookRepository.GetBookFullInfoById(bookId);
        }

        public IEnumerable<Book> GetBooksByAuthor(string authorName)
        {
            if (string.IsNullOrWhiteSpace(authorName))
            {
                throw new ArgumentException("Author cannot be empty!", nameof(authorName));
            }

            return _bookRepository.GetBooksByAuthor(authorName);
        }

        public IEnumerable<Book> GetBooksByGenre(string genreName)
        {
            return _bookRepository.GetBooksByAuthor(genreName);
        }

        public IEnumerable<Book> GetBorrowedBooksByMemberId(int memberId)
        {
            if (memberId < 0)
            {
                throw new ArgumentException("Member Id cannot be negative!", nameof(memberId));
            }

            return _bookRepository.GetBorrowedBooksByMemberId(memberId);
        }

        public void UpdateBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "The book parameter cannot be null.");
            }

            if (_bookRepository.GetBookById(book.Id) == null)
            {
                throw new InvalidOperationException("Book with this id does not exist!");
            }

            _bookRepository.UpdateBook(book);
        }

        public void DeleteBookById(int bookId)
        {
            if (bookId < 0)
            {
                throw new ArgumentException("Book Id cannot be negative!", nameof(bookId));
            }

            if (_bookRepository.GetBookById(bookId) == null)
            {
                throw new InvalidOperationException("Book with this id does not exist!");
            }

            _bookRepository.DeleteBookById(bookId);
        }
    }
}
