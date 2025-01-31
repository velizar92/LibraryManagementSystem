using LibraryManagementSystem.DataAccessLibrary.Repositories;
using LibraryManagementSystem.ModelsLibrary;
using LibraryManagementSystem.ServicesLibrary.Services;

namespace LibraryManagementSystem.UI.Forms
{
    public partial class UpdateMemberForm : Form
    {
        private readonly MemberService _memberService;

        public event EventHandler<MemberEventArgs> UpdatedMember;


        public UpdateMemberForm()
        {
            InitializeComponent();

            _memberService = new MemberService(new MemberRepository(ConnectionStrings.connectionString));
        }

        public string Id
        {
            get { return txtId.Text; }
            set { txtId.Text = value; }
        }

        public string FirstName
        {
            get { return txtFirstName.Text; }
            set { txtFirstName.Text = value; }
        }

        public string LastName
        {
            get { return txtLastName.Text; }
            set { txtLastName.Text = value; }
        }

        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }

        public string PhoneNumber
        {
            get { return txtPhoneNumber.Text; }
            set { txtPhoneNumber.Text = value; }
        }

        private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            Member member = new Member
            {
                Id = Convert.ToInt32(txtId.Text),
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtPhoneNumber.Text,
            };

            _memberService.UpdateMember(member);

            UpdatedMember?.Invoke(this, new MemberEventArgs(member));

            Close();
        }
    }
}
