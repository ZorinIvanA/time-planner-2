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
        public async Task<ActionResult> Get() =>
            Ok(await this.goalCategoriesRepository.GetAllAsync());


        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var result = await this.goalCategoriesRepository.GetAllAsync(x => x.Id == id);
            if (result.Any())
                return Ok(result);

            return BadRequest($"Категория цели с таким id={id} не найдена!");
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GoalCategory category)
        {
            if (category?.Name == null)
            {
                return BadRequest("Категория не передана или её имя пустое");
            }

            var result = await this.goalCategoriesRepository.AddCategory(category);

            return Created($"{this.HttpContext.Request.PathBase}/api/categories/{result}", null);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(GoalCategory category)
        {
            if (category?.Name == null)
            {
                return BadRequest("Категория не передана или её имя пустое");
            }

            //Здесь нужно обработать вариант, что такого id нет
            await this.goalCategoriesRepository.EditCategory(category);

            return Ok();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            //Здесь нужно обработать вариант, что такого id нет
            await this.goalCategoriesRepository.DeleteCategory(id);

            return Ok();
        }
    }
}
