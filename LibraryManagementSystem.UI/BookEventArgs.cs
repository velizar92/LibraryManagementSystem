using LibraryManagementSystem.ModelsLibrary;

namespace LibraryManagementSystem.UI
{
    public class BookEventArgs : EventArgs
    {
        public Book Book { get; }

        public BookEventArgs(Book book)
        {
            Book = book;
        }
    }
}
