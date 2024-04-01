using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timeplanner.Core.Implementations;
using Timeplanner.Core.Interfaces;
using TimePlanner.Domain.Interfaces;

namespace TimePlanner.Domain.Models
{
    public class Goal
    {
        IGoalsRepository goalsRepository;

        public Goal(IGoalsRepository repository)
        {
            this.goalsRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Guid Id { get; set; }
        public DateTime? CompletedDate { get; set; }
        public bool IsCompleted => this.CompletedDate.HasValue;

        public async Task<IOperationResult> CompleteAsync(DateTime? completeDate = null)
        {
            if (this.IsCompleted)
                return new ConflictResult("Цель уже выполнена!");

            if (completeDate.HasValue)
                this.CompletedDate = completeDate.Value;

            await this.goalsRepository.UpdateGoal(this);

            return new Success();
        }
    }
}
