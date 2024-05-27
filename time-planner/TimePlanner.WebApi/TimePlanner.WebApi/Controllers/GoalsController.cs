using Microsoft.AspNetCore.Mvc;
using TimePlanner.Domain.Interfaces;
using TimePlanner.Domain.Models;
using Timeplanner.Core.Implementations;
using Timeplanner.Core.Interfaces;

namespace TimePlanner.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        IGoalsRepository goalsRepository;
        IGoalsService goalsService;

        public GoalsController(IGoalsRepository goalsRepository, IGoalsService goalsService)
        {
            this.goalsRepository = goalsRepository ??
                throw new ArgumentNullException(nameof(goalsRepository));
            this.goalsService = goalsService ?? throw new ArgumentNullException(nameof(goalsService));
        }

        [HttpPost("complete")]
        public async Task<ActionResult> SetGoalAsCompleted(Guid goalId)
        {
            var goalsResult = await this.goalsRepository.GetGoalsByIdsAsync(goalId);
            if (!goalsResult.Successful)
                return BadRequest($"Цель c id {goalId} не найдена");

            var goal = goalsResult.Result.Single();
            var completeResult = await this.goalsService.CompleteAsync(goal);

            if (!completeResult.Successful)
                return BadRequest(completeResult.ErrorMessage);

            return Ok();
        }

        private async Task<ActionResult> ProcessResult(IOperationResult result)
        {
            if (result.Successful)
                return Ok();

            if (result is Timeplanner.Core.Implementations.ConflictResult conflict)
                return Conflict(conflict.ErrorMessage);

            if (result is ElementNotFound notFound)
                return BadRequest(notFound.ErrorMessage);

            if (result is ExceptionResult exception)
                return StatusCode(StatusCodes.Status500InternalServerError, exception.ErrorMessage);

            return StatusCode(StatusCodes.Status500InternalServerError, "Неизвестная ошибка");
        }

        private async Task<ActionResult> ProcessResult<T>(IOperationResult<T> result)            
        {
            if (result.Successful)
                return Ok(result.Result);

            if (result is Timeplanner.Core.Implementations.ConflictResult<T> conflict)
                return Conflict(conflict.ErrorMessage);

            if (result is ElementNotFound notFound)
                return BadRequest(notFound.ErrorMessage);

            if (result is ExceptionResult exception)
                return StatusCode(StatusCodes.Status500InternalServerError, exception.ErrorMessage);

            return StatusCode(StatusCodes.Status500InternalServerError, "Неизвестная ошибка");
        }
    }
}
