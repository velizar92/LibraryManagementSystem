namespace LibraryManagementSystem.ModelsLibrary
{
    public class Book : BaseDeletableEntity
    {
        public Book()
        {
            BorrowedBooks = new HashSet<BorrowedBooks>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string PublishedYear { get; set; }

        public ICollection<BorrowedBooks> BorrowedBooks { get; set; }
    }
}
