using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimePlanner.Domain.Models;
using TimePlanner.Infrastructure.EFCore.DTO;

namespace TimePlanner.Infrastructure.Mappers
{
    internal class PeriodMapper
    {
        public PeriodMapper()
        {

        }

        public TrackingPeriod MapFromDto(PeriodDto dto)
        {
            return new TrackingPeriod
            {
                Name = dto.Name,
                Id = dto.Id,
                EndDate = dto.EndDate,
                StartDate = dto.StartDate
            };
        }
    }
}
