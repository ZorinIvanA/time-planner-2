using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimePlanner.Domain.Models;

namespace TimePlanner.Infrastructure.EFCore.DTO
{
    [Table("goals")]
    [PrimaryKey(nameof(Id))]
    public class GoalDto
    {
        public Guid Id { get; set; }
        public DateTime? CompletedDate { get; set; }
        [Required]
        public DateTime DateToComplete { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? Parent { get; set; }
        [Required]
        internal PeriodDto Period { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public GoalCategoryDto Category { get; set; }
    }
}
