using LibraryManagementSystem.DataAccessLibrary.Repositories;
using LibraryManagementSystem.ServicesLibrary.Services;

namespace LibraryManagementSystem.UI.Forms
{
    public partial class MainboardForm : Form
    {
        private AddMemberForm _addMemberForm;
        private AddBookForm _addBookForm;
        private UpdateBookForm _updateBookForm;
        private UpdateMemberForm _updateMemberForm;
        private readonly MemberService _memberService;
        private readonly BookService _bookService;
        private readonly BorrowedBookService _borrowedBookService;

        public MainboardForm()
        {
            InitializeComponent();

            _memberService = new MemberService(new MemberRepository(ConnectionStrings.connectionString));

            _bookService = new BookService(new BookRepository(ConnectionStrings.connectionString), new BorrowedBookRepository(ConnectionStrings.connectionString));

            _borrowedBookService = new BorrowedBookService(new BorrowedBookRepository(ConnectionStrings.connectionString),
                new BookRepository(ConnectionStrings.connectionString), new MemberRepository(ConnectionStrings.connectionString));

            _addMemberForm = new AddMemberForm();
            _addMemberForm.AddedMember += _addMemberForm_AddedMember;

            _addBookForm = new AddBookForm();
            _addBookForm.AddedBook += _addBookForm_AddedBook;

            _updateBookForm = new UpdateBookForm();
            _updateBookForm.UpdatedBook += _updateBookForm_UpdatedBook;

            _updateMemberForm = new UpdateMemberForm();
            _updateMemberForm.UpdatedMember += _updateMemberForm_UpdatedMember;
        }


        private void MainboardForm_Load(object sender, EventArgs e)
        {
            InitializeMembersDataGridView();
            InitializeBooksDataGridView();

            var members = _memberService.GetAllMembers();
            var books = _bookService.GetAllBooks();

            foreach (var member in members)
            {
                dgvMembers.Rows.Add(member.Id, member.FirstName, member.LastName, member.Email, member.PhoneNumber);
            }

            foreach (var book in books)
            {
                dgvBooks.Rows.Add(book.Id, book.Title, book.Author, book.Genre, book.PublishedYear);
            }

            ColorizeAllBorrowedBooks(dgvBooks);
        }

        private void _addMemberForm_AddedMember(object? sender, MemberEventArgs e)
        {
            dgvMembers.Rows.Add(e.Member.Id, e.Member.FirstName, e.Member.LastName, e.Member.Email,
                e.Member.PhoneNumber);
        }

        private void _addBookForm_AddedBook(object? sender, BookEventArgs e)
        {
            dgvBooks.Rows.Add(e.Book.Id, e.Book.Title, e.Book.Author, e.Book.Genre,
               e.Book.PublishedYear);
        }

        private void _updateBookForm_UpdatedBook(object? sender, BookEventArgs e)
        {
            foreach (DataGridViewRow row in dgvBooks.Rows)
            {
                if (row.Cells["Id"].Value != null && row.Cells["Id"].Value.ToString() == e.Book.Id.ToString())
                {
                    dgvBooks.Rows.Remove(row);
                    break;
                }
            }

            dgvBooks.Rows.Add(e.Book.Id, e.Book.Title, e.Book.Author, e.Book.Genre,
                e.Book.PublishedYear);
        }

        private void _updateMemberForm_UpdatedMember(object? sender, MemberEventArgs e)
        {
            foreach (DataGridViewRow row in dgvMembers.Rows)
            {
                if (row.Cells["Id"].Value != null && row.Cells["Id"].Value.ToString() == e.Member.Id.ToString())
                {
                    dgvMembers.Rows.Remove(row);
                    break;
                }
            }

            dgvMembers.Rows.Add(e.Member.Id, e.Member.FirstName, e.Member.LastName, e.Member.Email,
                e.Member.PhoneNumber);
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
            dgvMembers.Columns.Add("Id", "Id");
            dgvMembers.Columns.Add("FirstName", "First Name");
            dgvMembers.Columns.Add("LastName", "Last Name");
            dgvMembers.Columns.Add("Email", "Email");
            dgvMembers.Columns.Add("PhoneNumber", "Phone Number");
        }

        private void InitializeBooksDataGridView()
        {
            dgvBooks.Columns.Add("Id", "Id");
            dgvBooks.Columns.Add("Title", "Title");
            dgvBooks.Columns.Add("Author", "Author");
            dgvBooks.Columns.Add("Genre", "Genre");
            dgvBooks.Columns.Add("PublishedYear", "Published Year");
        }


        private void ColorizeAllBorrowedBooks(DataGridView datagridView)
        {
            foreach (DataGridViewRow row in datagridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    int id = (int)row.Cells["Id"].Value;

                    bool isBorrowed = _borrowedBookService.IsBookBorrowed(id);

                    if (isBorrowed)
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
            }
        }


        private void dgvBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBooks.Rows[e.RowIndex];

                // Extract data from the selected row
                string id = row.Cells["Id"].Value.ToString();
                string title = row.Cells["Title"].Value.ToString();
                string author = row.Cells["Author"].Value.ToString();
                string genre = row.Cells["Genre"].Value.ToString();
                string publishedYear = row.Cells["PublishedYear"].Value.ToString();

                _updateBookForm.Id = id;
                _updateBookForm.Title = title;
                _updateBookForm.Author = author;
                _updateBookForm.Genre = genre;
                _updateBookForm.PublishedYear = publishedYear;

                if (_updateBookForm == null || _updateBookForm.IsDisposed)
                {
                    _updateBookForm = new UpdateBookForm()
                    {
                        Id = id,
                        Title = title,
                        Author = author,
                        Genre = genre,
                        PublishedYear = publishedYear
                    };

                    _updateBookForm.UpdatedBook += _updateBookForm_UpdatedBook;
                }

                _updateBookForm.Show();
            }
        }

        private void dgvMembers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMembers.Rows[e.RowIndex];

                // Extract data from the selected row
                string id = row.Cells["Id"].Value.ToString();
                string firstName = row.Cells["FirstName"].Value.ToString();
                string lastName = row.Cells["LastName"].Value.ToString();
                string email = row.Cells["Email"].Value.ToString();
                string phoneNumber = row.Cells["PhoneNumber"].Value.ToString();

                _updateMemberForm.Id = id;
                _updateMemberForm.FirstName = firstName;
                _updateMemberForm.LastName = lastName;
                _updateMemberForm.Email = email;
                _updateMemberForm.PhoneNumber = phoneNumber;

                if (_updateMemberForm == null || _updateMemberForm.IsDisposed)
                {
                    _updateMemberForm = new UpdateMemberForm()
                    {
                        Id = id,
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email,
                        PhoneNumber = phoneNumber
                    };

                    _updateMemberForm.UpdatedMember += _updateMemberForm_UpdatedMember;
                }

                _updateMemberForm.Show();
            }
        }
    }
}
