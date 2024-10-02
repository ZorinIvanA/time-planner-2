using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using TimePlanner.Infrastructure.EFCore.DTO;

namespace TimePlanner.Infrastructure.EFCore
{
    public class GoalsContext : DbContext
    {
        internal DbSet<GoalDto> Goals { get; set; }
        internal DbSet<GoalCategoryDto> GoalsCategories { get; set; }
        internal DbSet<PeriodDto> Periods { get; set; }

        public GoalsContext(DbContextOptions<GoalsContext> options) : base(options)
        {

        }
    }
}
