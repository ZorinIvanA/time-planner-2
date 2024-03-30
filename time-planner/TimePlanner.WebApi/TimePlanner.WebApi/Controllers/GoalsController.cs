using Microsoft.AspNetCore.Mvc;
using TimePlanner.Domain.Interfaces;
using TimePlanner.Domain.SuccessCodes;
using TimePlanner.Domain.Models;

namespace TimePlanner.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        IGoalsService goalsService;

        public GoalsController(IGoalsService goalsService)
        {
            this.goalsService = goalsService ??
                throw new ArgumentNullException(nameof(goalsService));
        }

        [HttpPost("complete")]
        public async Task<ActionResult> SetGoalAsCompleted(Guid goalId)
        {
            try
            {
                await this.goalsService.CompleteGoal(goalId);

                var completeResult = await this.goalsService.CompleteGoal(goalId);

                if (completeResult is ElementNotFound<Goal>)
                    return BadRequest("Цель не найдена");

                if (completeResult is ConflictResult<Goal> conflict)
                    return BadRequest(conflict.Message);

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
