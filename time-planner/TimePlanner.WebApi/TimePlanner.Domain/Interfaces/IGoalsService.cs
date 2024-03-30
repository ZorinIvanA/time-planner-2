using TimePlanner.Domain.SuccessCodes;

namespace TimePlanner.Domain.Interfaces
{
    public interface IGoalsService
    {
        Task<IResult> CompleteGoal(Guid guid);
    }
}
