using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimePlanner.Domain.Models
{
    public class Goal
    {
        public Guid Id { get; set; }
        public DateTime? CompletedDate { get; set; }
        public bool IsCompleted => this.CompletedDate.HasValue;
    }
}
