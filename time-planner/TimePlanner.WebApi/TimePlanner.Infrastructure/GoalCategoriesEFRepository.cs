using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimePlanner.Domain.Interfaces;
using TimePlanner.Domain.Models;

namespace TimePlanner.Infrastructure
{
    //Сюда пока не смотрим. Это обман чтобы набрать классы.
    public class GoalCategoriesEFRepository : IGoalCategoriesRepository
    {
        public Task<Guid> AddCategory(GoalCategory category)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategory(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task EditCategory(GoalCategory category)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GoalCategory>> GetAllAsync(Func<GoalCategory, bool> selectFunc = null)
        {
            throw new NotImplementedException();
        }
    }
}
