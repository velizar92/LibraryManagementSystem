using LibraryManagementSystem.DataAccessLibrary.Repositories;
using LibraryManagementSystem.ModelsLibrary;
using LibraryManagementSystem.ServicesLibrary.Services;

namespace LibraryManagementSystem.UI.Forms
{
    public partial class AddBookForm : Form
    {
        public event EventHandler<BookEventArgs> AddedBook;

        public AddBookForm()
        {
            InitializeComponent();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            BookService bookService = new BookService(new BookRepository(ConnectionStrings.connectionString), new BorrowedBookRepository(ConnectionStrings.connectionString));

            Book book = new Book
            {
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Genre = txtGenre.Text,
                PublishedYear = txtPublishedYear.Text,
            };

            int bookId = bookService.AddBook(book);
            book.Id = bookId;

            AddedBook?.Invoke(this, new BookEventArgs(book));

            MessageBox.Show("Book added successfully!");

            Close();
        }
    }

   
}
