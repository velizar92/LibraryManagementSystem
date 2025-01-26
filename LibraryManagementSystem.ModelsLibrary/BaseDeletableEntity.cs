namespace LibraryManagementSystem.ModelsLibrary
{
    public class BaseDeletableEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime DeletedOn { get; set; }
    }
}
