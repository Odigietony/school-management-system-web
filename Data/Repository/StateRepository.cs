using System.Linq;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Data.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly AppDbContext context;
        public StateRepository(AppDbContext context)
        {
            this.context = context;
        }
        public State GetRelatedCountry(long Id)
        {
            State state = context.States.FirstOrDefault(s => s.CountryId == Id);
            return state;
        }
    }
}