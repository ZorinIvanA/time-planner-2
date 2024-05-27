using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimePlanner.Domain.Models;

namespace TimePlanner.Infrastructure.EFCore.DTO
{
    internal class GoalDto
    {
        [Required]
        internal Guid Id { get; set; }
        internal DateTime? CompletedDate { get; set; }
        [Required]
        internal DateTime DateToComplete { get; set; }
        [Required]
        internal string Name { get; set; }
        internal string Description { get; set; }
        internal Guid? Parent { get; set; }
        [Required]
        internal PeriodDto Period { get; set; }
        [Required]
        internal Guid UserId { get; set; }
        internal GoalCategoryDto Category { get; set; }

        internal GoalDto(Goal goal)
        {
            if (goal == null) throw new ArgumentNullException(nameof(goal));

            this.Id = goal.Id;
            this.CompletedDate = goal.CompletedDate;
            this.Name = goal.Name;
        }
    }
}
