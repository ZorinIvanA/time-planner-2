using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimePlanner.Infrastructure.EFCore.DTO
{
    internal class PeriodDto
    {
        [Required]
        internal Guid Id { get; set; }
        [Required]
        internal string Name { get; set; }
        [Required]
        internal DateTime StartDate { get; set; }
        internal DateTime EndDate { get; set; }
        [Required]
        internal Guid UserId { get; set; }
    }
}
