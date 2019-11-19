namespace SchoolManagementSystem.Models
{
    public class Location
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long Number { get; set; }

        //Foreign Keys
        //[Location Category]
        public long LocationCategoryId { get; set; }
        public LocationCategory LocationCategory { get; set; }

        //[Admin]
        public long AdminId { get; set; }
        public Admin Admin { get; set; }
    }
}