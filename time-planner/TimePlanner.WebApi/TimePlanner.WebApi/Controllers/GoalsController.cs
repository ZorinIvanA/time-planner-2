using Microsoft.AspNetCore.Mvc;
using TimePlanner.Domain.Interfaces;
using TimePlanner.Domain.Models;
using Timeplanner.Core.Implementations;

namespace TimePlanner.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        IGoalsRepository goalsRepository;

        public GoalsController(IGoalsRepository goalsRepository)
        {
            this.goalsRepository = goalsRepository ??
                throw new ArgumentNullException(nameof(goalsRepository));
        }

        [HttpPost("complete")]
        public async Task<ActionResult> SetGoalAsCompleted(Guid goalId)
        {
            try
            {
                var goals = await this.goalsRepository.GetGoalsById(x => x.Id == goalId);
                if (!goals.Any())
                    return BadRequest($"Цель c id {goalId} не найдена");

                var goal = goals.Single();
                var completeResult = await goal.CompleteAsync();

                if (completeResult is ConflictResult<Goal> conflict)
                    return BadRequest(conflict.ErrorMessage);

                if (completeResult is Success)
                    return Ok();

                throw new NotImplementedException("До сюда дойти не должно!!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
