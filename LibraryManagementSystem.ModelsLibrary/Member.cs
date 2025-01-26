namespace LibraryManagementSystem.ModelsLibrary
{
    public class Member
    {
        public Member()
        {
            BorrowedBooks = new HashSet<BorrowedBooks>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<BorrowedBooks> BorrowedBooks { get; set; }
    }
}
