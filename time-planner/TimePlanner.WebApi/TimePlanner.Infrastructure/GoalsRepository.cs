using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimePlanner.Domain.Interfaces;
using TimePlanner.Domain.Models;

namespace TimePlanner.Infrastructure
{
    public class GoalsRepository : IGoalsRepository
    {
        public Task<IEnumerable<Goal>> GetGoalsById(Func<Goal, bool> selectFunc)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGoal(Goal goal)
        {
            throw new NotImplementedException();
        }
    }
}
