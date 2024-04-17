using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimePlanner.Domain.Models;

namespace TimePlanner.Infrastructure.EFCore.DTO
{
    public class GoalDto
    {
        [Required]
        public Guid Id { get; set; }
        public DateTime? CompletedDate { get; set; }
        [Required]
        public string Name { get; set; }

        public GoalDto(Goal goal)
        {
            if (goal == null) throw new ArgumentNullException(nameof(goal));

            this.Id = goal.Id;
            this.CompletedDate = goal.CompletedDate;
            this.Name = goal.Name;
        }
    }
}
