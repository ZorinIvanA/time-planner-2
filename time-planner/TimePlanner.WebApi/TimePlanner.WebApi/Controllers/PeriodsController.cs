using Microsoft.AspNetCore.Mvc;
using Serilog;
using Timeplanner.Core.Implementations;
using TimePlanner.Domain.Interfaces;
using TimePlanner.Domain.Models;
using TimePlanner.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TimePlanner.WebApi.Controllers
{
    [Route("api/v1/periods")]
    [ApiController]
    public class PeriodsController : ControllerBase
    {
        IGoalsPeriodsRepository goalPeriodsRepository;
        public PeriodsController(IGoalsPeriodsRepository repository)
        {
            this.goalPeriodsRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/v1/periods/566AED5D-CC38-47B5-BA84-8D20A69D4DC6
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var result = await this.goalPeriodsRepository.GetPeriodsByIdsAsync(id);
            var t = result.Result.ToList();

            if (t.Any())
                return Ok(t);

            return BadRequest($"Период с таким id={id} не найден!");
        }

        // GET api/v1/periods
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await this.goalPeriodsRepository.GetPeriodsAsync();
            var t = result.Result.ToList();

            return Ok(t);
        }
    }
}
