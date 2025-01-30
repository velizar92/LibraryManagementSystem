using LibraryManagementSystem.DataAccessLibrary.Repositories;
using LibraryManagementSystem.ServicesLibrary.Services;
using System.Windows.Forms;

namespace LibraryManagementSystem.UI
{
    public partial class MainboardForm : Form
    {
        private AddMemberForm _addMemberForm;
        public MainboardForm()
        {
            InitializeComponent();
            _addMemberForm = new AddMemberForm();
            _addMemberForm.AddedMember += _addMemberForm_AddedMember;
        }

        private void MainboardForm_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();
            MemberService memberService = new MemberService(new MemberRepository(ConnectionStrings.connectionString));

            var members = memberService.GetAllMembers();

            foreach (var member in members)
            {
                dgvMembers.Rows.Add(member.FirstName, member.LastName, member.Email, member.PhoneNumber);
            }
        }

        private void _addMemberForm_AddedMember(object? sender, MemberEventArgs e)
        {
            dgvMembers.Rows.Add(e.Member.FirstName, e.Member.LastName, e.Member.Email,
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
            AddBookForm addBookForm = new AddBookForm();
            addBookForm.Show();
        }

        private void InitializeDataGridView()
        {
            dgvMembers.Columns.Add("FirstName", "First Name");
            dgvMembers.Columns.Add("LastName", "Last Name");
            dgvMembers.Columns.Add("Email", "Email");
            dgvMembers.Columns.Add("PhoneNumber", "Phone Number");
        }

        
    }
}
