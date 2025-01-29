namespace LibraryManagementSystem.UI
{
    public partial class MainboardForm : Form
    {
        public MainboardForm()
        {
            InitializeComponent();
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            AddMemberForm addMemberForm = new AddMemberForm();
            addMemberForm.Show();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            AddBookForm addBookForm = new AddBookForm();
            addBookForm.Show();
        }
    }
}
