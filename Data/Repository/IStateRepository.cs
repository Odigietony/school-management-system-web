using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Data.Repository
{
    public interface IStateRepository
    {
        State GetRelatedCountry(long Id);
    }
}