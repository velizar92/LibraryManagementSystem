using LibraryManagementSystem.DataAccessLibrary.Repositories;
using LibraryManagementSystem.ModelsLibrary;
using LibraryManagementSystem.ServicesLibrary.Services;
using System.Windows.Forms;

namespace LibraryManagementSystem.UI
{
    public partial class AddMemberForm : Form
    {
        public AddMemberForm()
        {
            InitializeComponent();

        }

        private void AddMemberForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            MemberService memberService = new MemberService(new MemberRepository("conn_string"));
            memberService.AddMember(new Member
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtPhoneNumber.Text,
            });
        }    
    }
}
