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
        /// <summary>
        /// Id цели
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Дата, к которой цель должна быть выполнена
        /// </summary>
        public DateTime DateToComplete { get; set; }

        /// <summary>
        /// Дата выполнения цели
        /// </summary>
        public DateTime? CompletedDate { get; set; }
        /// <summary>
        /// Выполнена ли цель в настоящий момент
        /// </summary>
        public bool IsCompleted => this.CompletedDate.HasValue;
        /// <summary>
        /// Краткое название цели
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание цели
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Родительская цель
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Период цели
        /// </summary>
        public TrackingPeriod Period { get; set; }
    }
}
