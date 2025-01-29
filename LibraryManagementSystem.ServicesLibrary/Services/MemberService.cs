using LibraryManagementSystem.DataAccessLibrary.Repositories;
using LibraryManagementSystem.ModelsLibrary;

namespace LibraryManagementSystem.ServicesLibrary.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IBorrowedBookRepository borrowedBookRepository,
            IBookRepository bookRepository, IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }


        public void AddMember(Member member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member), "The member parameter cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(member.FirstName)
                || string.IsNullOrWhiteSpace(member.LastName)
                || string.IsNullOrWhiteSpace(member.Email))
            {
                throw new ArgumentException("FirstName, LastName and Email must be provided!");
            }

            _memberRepository.AddMember(member);
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _memberRepository.GetAllMembers();
        }

        public Member GetMemberByEmail(string memberEmail)
        {
            if (string.IsNullOrWhiteSpace(memberEmail))
            {
                throw new ArgumentException("Email must be provided!", nameof(memberEmail));
            }

            return _memberRepository.GetMemberByEmail(memberEmail);
        }

        public Member GetMemberById(int memberId)
        {
            if (memberId < 0)
            {
                throw new ArgumentException("Member Id cannot be negative!", nameof(memberId));
            }

            return _memberRepository.GetMemberById(memberId);
        }

        public Member GetMemberFullInfoById(int memberId)
        {
            if (memberId < 0)
            {
                throw new ArgumentException("Member Id cannot be negative!", nameof(memberId));
            }

            return _memberRepository.GetMemberFullInfoById(memberId);
        }

        public IEnumerable<Member> GetMembersByFirstName(string memberFirstName)
        {
            if (string.IsNullOrWhiteSpace(memberFirstName))
            {
                throw new ArgumentException("FirstName cannot be empty!", nameof(memberFirstName));
            }

            return _memberRepository.GetMembersByFirstName(memberFirstName);
        }

        public IEnumerable<Member> GetMembersByLastName(string memberLastName)
        {
            if (string.IsNullOrWhiteSpace(memberLastName))
            {
                throw new ArgumentException("FirstName cannot be empty!", nameof(memberLastName));
            }

            return _memberRepository.GetMembersByLastName(memberLastName);
        }

        public void UpdateMember(Member member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member), "The member parameter cannot be null.");
            }

            if(_memberRepository.GetMemberById(member.Id) == null)
            {
                throw new InvalidOperationException("Member with this id does not exist!");
            }

            _memberRepository.UpdateMember(member);
        }

        public void DeleteMemberById(int memberId)
        {
            if (memberId < 0)
            {
                throw new ArgumentException("Member Id cannot be negative!", nameof(memberId));
            }

            if (_memberRepository.GetMemberById(memberId) == null)
            {
                throw new InvalidOperationException("Member with this id does not exist!");
            }

            _memberRepository.DeleteMemberById(memberId);
        }
    }
}
