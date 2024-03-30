using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimePlanner.Domain.Models;

namespace TimePlanner.Domain.Interfaces
{
    public interface IGoalsRepository
    {
        Task<IEnumerable<Goal>> GetGoalsById(params Guid[] ids);

        Task UpdateGoal(Goal goal);
    }
}
