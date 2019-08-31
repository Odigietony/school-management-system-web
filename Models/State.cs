namespace SchoolManagementSystem.Models
{
    public class State
    {
        public long Id { get; set; }
        public string StateName { get; set; }

        public long CountryId { get; set; }
        public Country Country { get; set; }
    }
}