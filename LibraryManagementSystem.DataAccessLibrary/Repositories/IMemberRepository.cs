using LibraryManagementSystem.ModelsLibrary;

namespace LibraryManagementSystem.DataAccessLibrary.Repositories
{
    public interface IMemberRepository
    {
        void AddMember(Member member);
        Member GetMemberById(int memberId);
        Member GetMemberByEmail(string memberEmail);
        Member GetMemberFullInfoById(int memberId);
        IEnumerable<Member> GetMembersByFirstName(string memberFirstName);
        IEnumerable<Member> GetMembersByLastName(string memberLastName);
        IEnumerable<Member> GetAllMembers();
        void UpdateMember(Member member);
        void DeleteMemberById(int memberId);
    }
}
