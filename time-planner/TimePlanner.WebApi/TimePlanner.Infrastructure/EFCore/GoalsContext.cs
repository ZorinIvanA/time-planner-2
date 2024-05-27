using System.Data.Entity;
using TimePlanner.Infrastructure.EFCore.DTO;

namespace TimePlanner.Infrastructure.EFCore
{
    internal class GoalsContext : DbContext
    {
        internal DbSet<GoalDto> Goals { get; set; }
        internal DbSet<GoalCategoryDto> GoalsCategories { get; set; }
        internal DbSet<PeriodDto> Periods { get; set; } 
    }
}
