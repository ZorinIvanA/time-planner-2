using Npgsql.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timeplanner.Core.Implementations;
using Timeplanner.Core.Interfaces;
using TimePlanner.Domain.Interfaces;
using TimePlanner.Domain.Models;
using TimePlanner.Infrastructure.Base;
using TimePlanner.Infrastructure.EFCore;
using TimePlanner.Infrastructure.EFCore.DTO;
using TimePlanner.Infrastructure.Mappers;

namespace TimePlanner.Infrastructure.Repositories
{
    public class GoalsRepository : EfRepositoryBase<GoalDto, Goal, GoalsMapper>, IGoalsRepository
    {
        public GoalsRepository(GoalsContext context) : base(context)
        {

        }
        public Task<IOperationResult<IQueryable<Goal>>> GetGoalsByIdsAsync(params Guid[] ids)
        {
            var dtos = this.context.Goals.Where(x => ids.Any(y => y == x.Id))
                .Select(x => this.mapper.FromDto(x));

            return Task.FromResult(new Success<IQueryable<Goal>>(dtos) as IOperationResult<IQueryable<Goal>>);
        }

        public async Task<IOperationResult> UpdateGoalAsync(Goal goal)
        {
            if (goal == null) return new ExceptionResult(new ArgumentNullException(nameof(goal)));

            var foundGoal = this.context.Goals.FirstOrDefault(x => x.Id.Equals(goal.Id));
            if (foundGoal == null)
                return new ElementNotFound($"Цель с id {goal.Id} не найдена!");

            foundGoal.DateToComplete = goal.DateToComplete;
            foundGoal.CompletedDate = goal.CompletedDate;
            foundGoal.Description = goal.Description;
            foundGoal.Name = goal.Name;

            await this.context.SaveChangesAsync();

            return new Success();
        }

        protected override IQueryable<GoalDto> GetDataInternalAsync(Func<GoalDto, bool> selectFunc, int pageSize, int currentPage, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override GoalsMapper GetMapper()
        {
            return new GoalsMapper();
        }
    }
}
