using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimePlanner.Infrastructure.EFCore.DTO;

namespace TimePlanner.Infrastructure.EFCore
{
    public class GoalsContext : DbContext
    {
        public DbSet<GoalDto> Goals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=.;database=time-planner;");
        }
    }
}
