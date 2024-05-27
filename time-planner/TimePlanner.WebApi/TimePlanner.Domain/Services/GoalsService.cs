using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timeplanner.Core.Interfaces;
using TimePlanner.Domain.Interfaces;
using TimePlanner.Domain.Models;

namespace TimePlanner.Domain.Services
{
    public class GoalsService : IGoalsService
    {
        private IGoalsRepository goalsRepository;

        public GoalsService(IGoalsRepository goalsRepository)
        {
            this.goalsRepository = goalsRepository ?? throw new ArgumentNullException(nameof(goalsRepository));
        }

        public Task<IOperationResult> CompleteAsync(Goal goal)
        {
            if (goal == null) throw new ArgumentNullException(nameof(goal));

            goal.CompletedDate = DateTime.Now;

            return this.goalsRepository.UpdateGoalAsync(goal);
        }
    }
}
