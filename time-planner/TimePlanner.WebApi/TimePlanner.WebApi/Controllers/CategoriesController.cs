using Microsoft.AspNetCore.Mvc;
using Serilog;
using TimePlanner.Domain.Interfaces;
using TimePlanner.Domain.Models;
using TimePlanner.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TimePlanner.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        IGoalCategoriesRepository goalCategoriesRepository;
        public CategoriesController(IGoalCategoriesRepository repository)
        {
            this.goalCategoriesRepository = repository;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await this.goalCategoriesRepository.GetAllAsync());

        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
