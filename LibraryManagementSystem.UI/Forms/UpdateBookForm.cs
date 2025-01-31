using LibraryManagementSystem.DataAccessLibrary.Repositories;
using LibraryManagementSystem.ModelsLibrary;
using LibraryManagementSystem.ServicesLibrary.Services;

namespace LibraryManagementSystem.UI.Forms
{
    public partial class UpdateBookForm : Form
    {
        private readonly BookService _bookService;

        public event EventHandler<BookEventArgs> UpdatedBook;

        public UpdateBookForm()
        {
            InitializeComponent();

            _bookService = new BookService(new BookRepository(ConnectionStrings.connectionString));
        }

        public string Id
        {
            get { return txtId.Text; }
            set { txtId.Text = value; }
        }

        public string Title
        {
            get { return txtTitle.Text; }
            set { txtTitle.Text = value; }
        }

        public string Author
        {
            get { return txtAuthor.Text; }
            set { txtAuthor.Text = value; }
        }

        public string Genre
        {
            get { return txtGenre.Text; }
            set { txtGenre.Text = value; }
        }

        public string PublishedYear
        {
            get { return txtPublishedYear.Text; }
            set { txtPublishedYear.Text = value; }
        }


        private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            Book book = new Book
            {
                Id = Convert.ToInt32(txtId.Text),
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Genre = txtGenre.Text,
                PublishedYear = txtPublishedYear.Text
            };

            _bookService.UpdateBook(book);

            UpdatedBook?.Invoke(this, new BookEventArgs(book));
        }
    }
}
