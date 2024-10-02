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
    public class GoalsPeriodsRepository : EfRepositoryBase<PeriodDto, TrackingPeriod, PeriodMapper>, IGoalsPeriodsRepository
    {
        public GoalsPeriodsRepository(GoalsContext context) : base(context)
        {

        }

        public Task<IOperationResult<IEnumerable<TrackingPeriod>>> GetPeriodsByIdsAsync(params Guid[] ids)
        {
            var dtos = this.context.Periods.Where(x => ids.Any(y => y == x.Id))
                .Select(x => this.mapper.FromDto(x));

            return Task.FromResult(new Success<IEnumerable<TrackingPeriod>>(dtos) as IOperationResult<IEnumerable<TrackingPeriod>>);
        }

        public Task<IOperationResult<IEnumerable<TrackingPeriod>>> GetPeriodsAsync()
        {
            var result = this.context.Periods
                .Select(x => this.mapper.FromDto(x));

            return Task.FromResult(new Success<IEnumerable<TrackingPeriod>>(result) as IOperationResult<IEnumerable<TrackingPeriod>>);
        }

        protected override IQueryable<PeriodDto> GetDataInternalAsync(Func<PeriodDto, bool> selectFunc, int pageSize, int currentPage, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override PeriodMapper GetMapper() => new PeriodMapper();
    }
}
