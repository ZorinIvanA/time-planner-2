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
    public class GoalCategoriesEFRepository : IGoalCategoriesRepository
    {
        DbContext context;

        public GoalCategoriesEFRepository(IConfiguration configuration)
        {
            //this.context = new DbContext();
        }
        public Task<IEnumerable<GoalCategory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
