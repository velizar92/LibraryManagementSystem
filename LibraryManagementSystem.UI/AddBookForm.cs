using LibraryManagementSystem.DataAccessLibrary.Repositories;
using LibraryManagementSystem.ModelsLibrary;
using LibraryManagementSystem.ServicesLibrary.Services;
using System.Windows.Forms;

namespace LibraryManagementSystem.UI
{
    public partial class AddBookForm : Form
    {
        public AddBookForm()
        {
            InitializeComponent();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            BookService bookService = new BookService(new BookRepository("conn_string"));
            bookService.AddBook(new Book
            {
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Genre = txtGenre.Text,
                PublishedYear = txtPublishedYear.Text,
            });
        }
    }
}
