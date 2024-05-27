using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimePlanner.Domain.Interfaces;
using TimePlanner.Domain.Models;
using TimePlanner.Infrastructure.EFCore.DTO;

namespace TimePlanner.Infrastructure.Mappers
{
    internal class GoalsMapper
    {
        IGoalsRepository repository;

        public GoalsMapper(IGoalsRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Goal MapFromModel(GoalDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var peiodMapper = new PeriodMapper();
            return new Goal()
            {
                CompletedDate = dto.CompletedDate,
                DateToComplete = dto.DateToComplete,
                Description = dto.Description,
                Id = dto.Id,
                Name = dto.Name,
                ParentId = dto.Parent,
                Period = peiodMapper.MapFromDto(dto.Period)
            };
        }
    }
}
