using LibraryManagementSystem.DataAccessLibrary.Repositories;
using LibraryManagementSystem.ModelsLibrary;
using LibraryManagementSystem.ServicesLibrary.Services;

namespace LibraryManagementSystem.UI
{
    public partial class AddMemberForm : Form
    {
        public event EventHandler<MemberEventArgs> AddedMember;
        
        public AddMemberForm()
        {
            InitializeComponent();
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            MemberService memberService = new MemberService(new MemberRepository(ConnectionStrings.connectionString));

            Member member = new Member()
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtPhoneNumber.Text,
            };

            memberService.AddMember(member);  
            AddedMember?.Invoke(this, new MemberEventArgs(member));

            MessageBox.Show("Member added successfully!");

            Close();
        }
    }

    public class MemberEventArgs : EventArgs
    {
        public Member Member { get; }

        public MemberEventArgs(Member member)
        {
            Member = member;
        }
    }
}
