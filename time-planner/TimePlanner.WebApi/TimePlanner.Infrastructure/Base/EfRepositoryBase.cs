using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimePlanner.Infrastructure.EFCore;
using TimePlanner.Infrastructure.Interfaces;

namespace TimePlanner.Infrastructure.Base
{
    public abstract class EfRepositoryBase<TDto, TModel, TMapper>
        where TDto : class, new()
        where TModel : class, new()
        where TMapper : IMapper<TDto, TModel>
    {
        protected GoalsContext context;
        protected TMapper mapper;
        protected EfRepositoryBase(GoalsContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = this.GetMapper();
        }

        /// <summary>
        /// Асинхронно возвращает элементы указанного класса-dto. Должен быть описан в репозитории.
        /// </summary>
        /// <param name="selectFunc">Функция отбора</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="currentPage">Номер текущей страницы (с 0)</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        protected abstract IQueryable<TDto> GetDataInternalAsync(Func<TDto, bool> selectFunc,
            int pageSize,
            int currentPage,
            CancellationToken cancellationToken);

        /// <summary>
        /// При переопределении в классе-наследнике возвращает необходимый инстанс маппера
        /// </summary>
        protected abstract TMapper GetMapper();
    }
}
