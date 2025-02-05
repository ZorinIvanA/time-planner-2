using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimePlanner.Domain.Models;
using TimePlanner.Infrastructure.EFCore.DTO;
using TimePlanner.Infrastructure.Interfaces;

namespace TimePlanner.Infrastructure.Mappers
{
    public class PeriodMapper : IMapper<PeriodDto, TrackingPeriod>
    {
        public PeriodMapper()
        {

        }

        public TrackingPeriod FromDto(PeriodDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            return new TrackingPeriod
            {
                Name = dto.Name,
                Id = dto.Id,
                EndDate = dto.EndDate,
                StartDate = dto.StartDate
            };
        }

        public PeriodDto ToDto(TrackingPeriod entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return new PeriodDto
            {
                Name = entity.Name,
                Id = entity.Id,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate
            };
        }
    }
}
