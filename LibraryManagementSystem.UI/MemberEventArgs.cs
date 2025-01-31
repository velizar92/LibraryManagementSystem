using LibraryManagementSystem.ModelsLibrary;

namespace LibraryManagementSystem.UI
{
    public class MemberEventArgs
    {
        public Member Member { get; }

        public MemberEventArgs(Member member)
        {
            Member = member;
        }
    }
}
