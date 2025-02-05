using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimePlanner.Domain.Interfaces;
using TimePlanner.Domain.Models;
using TimePlanner.Infrastructure.EFCore.DTO;
using TimePlanner.Infrastructure.Interfaces;

namespace TimePlanner.Infrastructure.Mappers
{
    public class GoalsMapper : IMapper<GoalDto, Goal>
    {

        public GoalsMapper()
        {
        }

        public Goal FromDto(GoalDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var peiodMapper = new PeriodMapper(); //TODO: переделать на DI
            return new Goal()
            {
                CompletedDate = dto.CompletedDate,
                DateToComplete = dto.DateToComplete,
                Description = dto.Description,
                Id = dto.Id,
                Name = dto.Name,
                ParentId = dto.Parent,
                Period = peiodMapper.FromDto(dto.Period)
            };
        }

        public GoalDto ToDto(Goal entity)
        {
            throw new NotImplementedException();
        }
    }
}
