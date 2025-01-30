using LibraryManagementSystem.DataAccessLibrary.Repositories;
using LibraryManagementSystem.ServicesLibrary.Services;

namespace LibraryManagementSystem.UI
{
    public partial class MainboardForm : Form
    {
        private AddMemberForm _addMemberForm;
        private AddBookForm _addBookForm;
        public MainboardForm()
        {
            InitializeComponent();
            _addMemberForm = new AddMemberForm();
            _addMemberForm.AddedMember += _addMemberForm_AddedMember;

            _addBookForm = new AddBookForm();
            _addBookForm.AddedBook += _addBookForm_AddedBook;
        }

    
        private void MainboardForm_Load(object sender, EventArgs e)
        {
            InitializeMembersDataGridView();
            InitializeBooksDataGridView();

            MemberService memberService = new MemberService(new MemberRepository(ConnectionStrings.connectionString));

            BookService bookService = new BookService(new BookRepository(ConnectionStrings.connectionString));

            var members = memberService.GetAllMembers();
            var books = bookService.GetAllBooks();

            foreach (var member in members)
            {
                dgvMembers.Rows.Add(member.FirstName, member.LastName, member.Email, member.PhoneNumber);
            }

            foreach (var book in books)
            {
                dgvBooks.Rows.Add(book.Title, book.Author, book.Genre, book.PublishedYear);
            }
        }

        private void _addMemberForm_AddedMember(object? sender, MemberEventArgs e)
        {
            dgvMembers.Rows.Add(e.Member.FirstName, e.Member.LastName, e.Member.Email,
                e.Member.PhoneNumber);
        }

        private void _addBookForm_AddedBook(object? sender, BookEventArgs e)
        {
            dgvBooks.Rows.Add(e.Book.Title, e.Book.Author, e.Book.Genre,
               e.Book.PublishedYear);
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            if (_addMemberForm == null || _addMemberForm.IsDisposed)
            {
                _addMemberForm = new AddMemberForm();
                _addMemberForm.AddedMember += _addMemberForm_AddedMember;
            }

            _addMemberForm.Show();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            if (_addBookForm == null || _addBookForm.IsDisposed)
            {
                _addBookForm = new AddBookForm();
                _addBookForm.AddedBook += _addBookForm_AddedBook;
            }

            _addBookForm.Show();
        }

        private void InitializeMembersDataGridView()
        {
            dgvMembers.Columns.Add("FirstName", "First Name");
            dgvMembers.Columns.Add("LastName", "Last Name");
            dgvMembers.Columns.Add("Email", "Email");
            dgvMembers.Columns.Add("PhoneNumber", "Phone Number");
        }

        private void InitializeBooksDataGridView()
        {
            dgvBooks.Columns.Add("Title", "Title");
            dgvBooks.Columns.Add("Author", "Author");
            dgvBooks.Columns.Add("Genre", "Genre");
            dgvBooks.Columns.Add("PublishedYear", "Published Year");
        }
    }
}
