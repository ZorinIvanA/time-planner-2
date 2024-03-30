using TimePlanner.Domain.Interfaces;
using TimePlanner.Domain.Models;
using TimePlanner.Domain.SuccessCodes;

namespace TimePlanner.Domain.Services
{
    public class GoalsService : IGoalsService
    {
        IGoalsRepository goalsRepository;

        public GoalsService(IGoalsRepository goalsRepository)
        {
            this.goalsRepository = goalsRepository ??
                throw new ArgumentNullException(nameof(goalsRepository));
        }

        public async Task<IResult> CompleteGoal(Guid goalId)
        {
            var goal = (await goalsRepository.GetGoalsById(goalId))
                .FirstOrDefault();

            if (goal == null)
                return new ElementNotFound<Goal>();

            if (goal.IsCompleted)
                return new ConflictResult<Goal>("Цель уже выполнена!");

            goal.CompletedDate = DateTime.Now;
            await this.goalsRepository.UpdateGoal(goal);

            return new Success();
        }
    }
}
